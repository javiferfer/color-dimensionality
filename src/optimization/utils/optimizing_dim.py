import math
import matplotlib.pyplot as plt
import numpy as np


def angle_method(error_s, min_no_dim, max_no_dim, plot_curve=False):
    angle_s = []
    angle_s.append(None)
    for i in range(len(error_s) - 2):
        angle = (np.arctan(error_s[i+2] - error_s[i+1]) - np.arctan(error_s[i+1] - error_s[i])) * 180 / math.pi
        angle_s.append(angle)
    angle_s.append(None)
    angle_s = np.array(angle_s)

    if plot_curve == True:
        fig, axs = plt.subplots(1, 1, figsize=(5, 5))
        axs.plot(error_s, linestyle='--', marker='o', label='Error')
        axs.set_xlabel('No dim')
        axs.set_ylabel('Error')
        axs_rev = axs.twinx()
        axs_rev.plot(angle_s, linestyle='--', marker='o', color='orange', label='Angle')
        plt.locator_params(axis='x', nbins=MAX_NO_DIM-MIN_NO_DIM)
        labels = np.arange(0, MAX_NO_DIM)
        axs.set_xticklabels(labels)
        axs_rev.set_xlabel('No dim')
        axs_rev.set_ylabel('Angle (Degrees)')
        h1, l1 = axs.get_legend_handles_labels()
        h2, l2 = axs_rev.get_legend_handles_labels()
        axs.legend(h1+h2, l1+l2)
    return angle_s


def slope_method(error_s, min_no_dim, max_no_dim, plot_curve=False):
    slope_s = []
    slope_s.append(None)
    no_dim_s = np.arange(min_no_dim, max_no_dim)
    for i in range(len(error_s) - 2):
        slope = (error_s[i+2] - error_s[i+1]) - (error_s[i+1] - error_s[i])
        slope_s.append(slope)
    slope_s.append(None)
    slope_s = np.array(slope_s)

    if plot_curve == True:
        fig, axs = plt.subplots(1, 1, figsize=(5, 5))
        axs.plot(error_s, linestyle='--', marker='o', label='Error')
        axs.set_xlabel('No dim')
        axs.set_ylabel('Error')
        axs_rev = axs.twinx()
        axs_rev.plot(slope_s, linestyle='--', marker='o', color='orange', label='Slope')
        axs_rev.set_xticklabels(np.arange(min_no_dim, max_no_dim) - 0.5, fontsize=12)
        axs_rev.set_xlabel('No dim')
        axs_rev.set_ylabel('Slope')
        h1, l1 = axs.get_legend_handles_labels()
        h2, l2 = axs_rev.get_legend_handles_labels()
        axs.legend(h1+h2, l1+l2)
    return slope_s
