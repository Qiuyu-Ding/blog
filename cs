# python /home/ma-user/work/ding/data/xlm_para/replace.py

import os
import torch
import numpy
from tqdm import tqdm

# en_open = open('/home/ma-user/work/ding/data/medicine_all/medicine_new20220111/medicine_wiki.en','r')
# zh_open = open('/home/ma-user/work/ding/data/medicine_all/medicine_new20220111/medicine_wiki.zh','r')

en_open = open('/home/ma-user/work/ding/data/test/test.en','r')
zh_open = open('/home/ma-user/work/ding/data/test/test.zh','r')

dict_open_zh2en = open('/home/ma-user/work/ding/code/MUSE-master/data/crosslingual/dictionaries/en-zh.txt','r')
dict_open_en2zh = open('/home/ma-user/work/ding/code/MUSE-master/data/crosslingual/dictionaries/zh-en.txt','r')

# en2zh_out = open('/home/ma-user/work/ding/data/medicine_all/medicine_new20220111/medicine_wiki-CS/medicine_wiki-CS.en','w')
# zh2en_out = open('/home/ma-user/work/ding/data/medicine_all/medicine_new20220111/medicine_wiki-CS/medicine_wiki-CS.zh','w')

en2zh_out = open('/home/ma-user/work/ding/data/test/test.enCS','w')
zh2en_out = open('/home/ma-user/work/ding/data/test/test.zhCS','w')

en_lines = en_open.readlines()
zh_lines = zh_open.readlines()
dict_lines_zh2en = dict_open_zh2en.readlines()
dict_lines_en2zh = dict_open_en2zh.readlines()

dict_ws_en2zh = {} 
dict_ws_zh2en = {}

#词典中的第一个词
for ws_zh2en in dict_lines_zh2en:
    w1, w2 = ws_zh2en.strip().split()
    dict_ws_zh2en[w2]=w1

for ws_en2zh in dict_lines_en2zh:
    w1, w2 = ws_en2zh.strip().split()
    dict_ws_en2zh[w2]=w1
    
for en_l in tqdm(en_lines):
    en_ws_old = en_l.strip().split()
    en_ws_new = []

    replace_words_en = []
    #replace word number替换到第几个词
    rw_n = 0
    for en_w in en_ws_old:
        if en_w in dict_ws_en2zh:
            replace_words_en.append(en_w)
        for i in range(len(replace_words_en)):
            if en_w == replace_words_en[i]:
                en_ws_new.append(dict_ws_en2zh[en_w])
            else:
                en_ws_new.append(en_w)
        en2zh_out.write(' '.join(en_ws_new)+'\n')
#     en2zh_out.write(' '.join(en_ws_old)+'\n')

    
# for en_l in tqdm(en_lines):
#     en_ws_old = en_l.strip().split()
#     en_ws_new = []
#     i = 0
#     for en_w in en_ws_old:
#         #如果句子中的词在词典中，对于词汇按序替换并写入
#         #计数器，替换到第i个词

#         if en_w in list(dict_ws_en2zh.values())[i]:
#             en_ws_new.append(dict_ws_en2zh[en_w])
#         else:
#             en_ws_new.append(en_w)
#         i= i+1
        
#     en2zh_out.write(' '.join(en_ws_old)+'\n')
#     if en_ws_new != en_ws_old:
#         en2zh_out.write(' '.join(en_ws_new)+'\n')
    
        
for zh_l in tqdm(zh_lines):
    zh_ws_old = zh_l.strip().split()
    zh_ws_new = []
    i = 0
    for zh_w in zh_ws_old:
        if zh_w in list(dict_ws_zh2en.values())[i]:
            zh_ws_new.append(dict_ws_zh2en[zh_w])
        else:
            zh_ws_new.append(zh_w)
        i = i+1
    
    zh2en_out.write(' '.join(zh_ws_old)+'\n')
    if zh_ws_new != zh_ws_old:
        zh2en_out.write(' '.join(zh_ws_new)+'\n')
