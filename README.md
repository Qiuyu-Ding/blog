# blog
##Bilingual Lexicon Induction with Semi-supervision in Non-Isometric Embedding Spaces 2019 acl finding
Motivation：
  1. 现在的双语词典抽取工作比较依赖一个对齐的双语词典或者词分布，通常会假设在两个空间是等距的，但是这种假设在某些场景下可能并不合理。
         eg：对于词源比较遥远的语言对，它们的空间距离也会更遥远。
     因此这篇工作提出对两个嵌入空间之间的距离做定量估计：Bilingual Lexicon Induction with Semi-Supervision (BLISS)
Introduction：
   1. 对于BLI，常用且有效地方法是学习在两个词嵌入空间之间的正交映射，此时会假设两个语言的词嵌入空间是正交的。
   2. 已有工作证明了这种强假设可能存在不合理性，因此作者
      - 首先使用Gromov-Hausdroff（GH）距离来检查正交假设成立的程度；
        particularly for etymologically and typologically distant language pairs.
      - 提出BLISS
        jointly optimizes for supervised embedding alignment, unsupervised distribution matching, and a weak orthogonality constraint in the form of a back-translation loss.
Methods：
   1. Isometry of Embedding Spaces
      使用Gromov Hausdorff (GH) distance检测在正交转换下两个语言的词嵌入空间的对齐程度。
      *Hausdorff distance：
      ![image](https://user-images.githubusercontent.com/72425683/142983621-6ad43f64-8180-480b-81cc-c6cbcc5f9030.png)
      测量两个空间的相似度程度（https://www.cnblogs.com/yhlx125/p/5478147.html）
      ![image](https://user-images.githubusercontent.com/72425683/142985792-1bb5e66c-27f0-485d-a575-64eaac4a2000.png)
      *Gromov Hausdorff (GH) distance是使所有正交变换上的Hausdorff distance最小化，使得能够提供一个确切的对于两个空间正交程度的定估计。
      ![image](https://user-images.githubusercontent.com/72425683/142986376-f320718b-6d98-487b-abf8-354421aae247.png)
   
   2. Semi-supervised Framework
      - 有监督方法缺点：仅仅对齐词，而没有利用到词嵌入中包含的丰富信息
      - 无监督方法缺点：利用词分布，只能对齐较粗粒度，细粒度对齐效果不好
