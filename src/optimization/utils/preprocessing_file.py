import numpy as np
import pandas as pd
import re
import sys


def preprocess_two_colors(df, no_colors):
    color_s = []
    for i in range(no_colors):
        for j in range(i+1, no_colors):
            comb_first_element, comb_second_element = f'color_{i}', f'color_{j}'
            index_s = []
            for index, row in df.iterrows():
                row_val = row.to_numpy()
                if (comb_first_element in row_val) and (comb_second_element in row_val):
                    order_img_elem = [int(re.split('_', row[0])[1]), 
                                      int(re.split('_', row[1])[1])]
                    order_img_elem.append(row_val[2])
                    color_s.append(order_img_elem)
                    index_s.append(index)
            assert len(index_s) == 1, f'There is a repeated combination: {index_s}'
    color_s = np.array(color_s)

    df_color = pd.DataFrame(color_s, columns=['left', 'right', 'slider'])
    return df_color


def preprocess_three_colors(df, no_colors):
    color_s = []
    for i in range(no_colors):
        for j in range(i+1, no_colors):
            for k in range(j+1, no_colors):
                centre_color, left_color, right_color = f'color_{i}', f'color_{j}', f'color_{k}'
                index_s = []
                for index, row in df.iterrows():
                    row_val = row.to_numpy()
                    if (centre_color in row_val) and (left_color in row_val) and (right_color in row_val):
                        order_img_elem = [int(re.split('_', row[0])[1]), 
                                          int(re.split('_', row[1])[1]),
                                          int(re.split('_', row[2])[1])]
                        order_img_elem.append(row_val[3])
                        color_s.append(order_img_elem)
                        index_s.append(index)
                assert len(index_s) == 1, f'There is a repeated combination: {index_s}'
    color_s = np.array(color_s)

    df_color = pd.DataFrame(color_s, columns=['center', 'left', 'right', 'slider'])
    return df_color


def adjust_slider(df, no_colors):
    if no_colors == 2:
        df['slider'] = ((df['slider'] / 10) - 1).abs()
    elif no_colors == 3:
        df['slider'] = ((df['slider'] + 5) / 10).abs()
    else:
        sys.exit('Number of colors not defined')
    return df
