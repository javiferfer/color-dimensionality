import matplotlib.pyplot as plt
import numpy as np
from sklearn.decomposition import PCA


COLOR_RGB = np.array([[0.12890625, 0.03125, 0.1640625],
                    [0, 0.1171875, 0.171875],
                    [0.6171875, 0.82421875, 0.8515625],
                    [0.62890625, 0.4453125, 0],
                    [0.99609375, 0.74609375,  0.76171875],
                    [0.63671875, 0.3046875, 0.94140625],
                    [0.234375, 0, 0],
                    [0.26953125, 0.390625, 0.5],
                    [0.69921875, 0.1796875, 0.23828125],
                    [0.99609375, 0.6015625, 0.671875],
                    [0, 0.19921875, 0.4140625],
                    [0.67578125, 0, 0.99609375],
                    [0.4140625, 0.7109375, 0.92578125],
                    [0.69140625, 0.21484375, 0],
                    [0.99609375, 0.58203125, 0],
                    [0.234375, 0.29296875, 0.2734375],
                    [0.83984375, 0.79296875, 0.484375],
                    [0.4140625, 0.23828125,  0.078125],
                    [0.421875, 0.48828125, 0.5390625],
                    [0, 0.890625, 0.98046875]])


def embedding(pos_s, no_dim):
    pos_s = np.reshape(pos_s, (-1, no_dim))
    if no_dim == 1:
        print('Number of dimensions needs to be higher than one')
    elif no_dim >= 2:
        pca = PCA(n_components=2)
        pos_s = pca.fit_transform(pos_s)
        for i, pos in enumerate(pos_s):
            print(f'Color {i} {pos}')
        plt.figure(figsize=(10, 5))
        plt.scatter(pos_s[:, 0], pos_s[:, 1], c=COLOR_RGB[:len(pos_s)])
