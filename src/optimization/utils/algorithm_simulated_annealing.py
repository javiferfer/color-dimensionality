import math
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
import sys
from scipy.spatial import distance


class SimulatedAnnealing():
    def __init__(self, no_iterations, step_size, temp, no_colors, no_dim, comb_colors):
        # define the total iterations
        self.n_iterations = no_iterations
        # define the maximum step size
        self.step_size = step_size
        # initial temperature
        self.temp = temp
        # number of colors
        self.no_colors = no_colors
        # number of dimensions
        self.no_dim = no_dim
        # objective function
        self.comb_colors = comb_colors

    # objective function
    def objective_two_colors(self, df, pred_pos):        
        loss, counter = 0, 0
        dist_s = pd.DataFrame([], columns=['real', 'estimated'])
        for i in range(self.no_colors):
            for j in range(i+1, self.no_colors):
                first_color, second_color, dist = df.iloc[counter]
                pos_first_color = pred_pos[int(first_color) * self.no_dim:(int(first_color) + 1) * self.no_dim]
                pos_second_color = pred_pos[int(second_color) * self.no_dim:(int(second_color) + 1) * self.no_dim]
                dist_estimated = distance.euclidean(pos_first_color, pos_second_color)
                loss += np.abs(dist - dist_estimated)
                counter += 1
                dist_s = dist_s.append({'real': dist, 'estimated': dist_estimated}, ignore_index=True)
        return loss, dist_s

    # objective function
    def objective_three_colors(self, df, pred_pos):        
        loss, counter = 0, 0
        dist_s = pd.DataFrame([], columns=['real', 'estimated'])
        for i in range(self.no_colors):
            for j in range(i+1, self.no_colors):
                for k in range(j+1, self.no_colors):
                    centre_color, left_color, right_color, dist = df.iloc[counter]
                    pos_center = pred_pos[int(centre_color) * self.no_dim:(int(centre_color) + 1) * self.no_dim]
                    pos_left = pred_pos[int(left_color) * self.no_dim:(int(left_color) + 1) * self.no_dim]
                    pos_right = pred_pos[int(right_color) * self.no_dim:(int(right_color) + 1) * self.no_dim]
                    dist_estimated = np.linalg.norm((pos_left, pos_center), 2) / np.linalg.norm((pos_left, pos_right), 2)
                    loss += np.abs(dist - dist_estimated)
                    counter += 1
                    dist_s = dist_s.append({'real': dist, 'estimated': dist_estimated}, ignore_index=True)
        return loss, dist_s

    # simulated annealing algorithm
    def run(self, df, bounds, n_iterations, step_size, temp):
        # generate an initial point
        best = bounds[:, 0] + np.random.rand(len(bounds)) * (bounds[:, 1] - bounds[:, 0])
        # evaluate the initial point
        if self.comb_colors == 2:
            best_eval, _ = self.objective_two_colors(df, best)
        elif self.comb_colors == 3:
            best_eval, _ = self.objective_three_colors(df, best)
        else:
            sys.exit()
        # current working solution
        curr, curr_eval = best, best_eval
        scores = []
        # run the algorithm
        for i in range(n_iterations):
            # take a step
            candidate = curr + np.random.randn(len(bounds)) * step_size
            # evaluate candidate point
            if self.comb_colors == 2:
                candidate_eval, _ = self.objective_two_colors(df, candidate)
            elif self.comb_colors == 3:
                candidate_eval, _ = self.objective_three_colors(df, candidate)
            else:
                sys.exit()
            # check for new best solution
            if candidate_eval < best_eval:
                # store new best point
                best, best_eval = candidate, candidate_eval
                # keep track of scores
                scores.append(best_eval)
                # report progress
                # print('>%d f(%s) = %.5f' % (i, best, best_eval))
            # difference between candidate and current point evaluation
            diff = candidate_eval - curr_eval
            # calculate temperature for current epoch
            t = temp / float(i + 1)
            # calculate metropolis acceptance criterion
            # the higher the temperature, the higher the number
            try:
                metropolis = math.exp(-diff / t)
            except:
                metropolis = -1e6
            # check if we should keep the new point
            if diff < 0 or np.random.rand() < metropolis:
                # store the new current point
                curr, curr_eval = candidate, candidate_eval
        return [best, best_eval, scores]
    
    def plot_iteration_curve(self, scores):
        # line plot of best scores
        plt.figure()
        plt.plot(scores, '.-')
        plt.xlabel('Improvement Number')
        plt.ylabel('Evaluation f(x)')