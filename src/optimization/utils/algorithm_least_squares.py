import numpy as np
import pandas as pd
import scipy
from scipy.spatial import distance
import sklearn.metrics as metrics


class LeastSquares():
    def __init__(self, no_colors, no_dim, comb_colors, seed=16):
        self.no_colors = no_colors
        self.no_dim = no_dim
        self.seed = seed
        self.comb_colors = comb_colors

    def objective(self, pos_s, order_values):
        pos_s = pos_s.reshape(-1, self.no_dim)
        order_values = order_values.reshape(-1, 2)
        for i, val in enumerate(order_values):       
            pos_first_color = pos_s[val[0]]
            pos_second_color = pos_s[val[1]]
            eq = distance.euclidean(pos_first_color, pos_second_color)
            eq_s = eq if i == 0 else np.hstack((eq_s, eq))
        return eq_s

    def system(self, init_pos, order_values, slider_s):
        return (self.objective(init_pos, order_values) - slider_s)

    def run(self, df):
        np.random.seed(self.seed)
        init_pos = np.random.rand(self.no_colors, self.no_dim)
        
        order_img = df.iloc[:, :-1].to_numpy()
        slider = df.iloc[:, -1].to_numpy()
        new_pos = scipy.optimize.leastsq(self.system, init_pos, args=(order_img, slider))[0]
        new_pos = new_pos.reshape(self.no_colors, self.no_dim)
        dist_s = self.objective(new_pos, order_img)
        error = metrics.mean_absolute_error(dist_s, slider) * len(dist_s)
        return [error, new_pos, dist_s]
