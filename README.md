# 概要
Switch クロノ・クロス(Chrono Cross)のセーブデータ編集Tool

# ソフト
https://www.jp.square-enix.com/cc_rd/

# 実行に必要
* Windows マシン
* .NET 6.0の導入
* セーブデータの吸い出し
* セーブデータの書き戻し

# Build環境
* Windows 10(64bit)
* Visual Studio 2022

# 編集時の手順
* saveDataを吸い出す
   * 結果、以下が取得可能
      * memcard1.mcr
      * memcard2.mcr
* memcard*.mcrを読み込む
* 任意の編集を行う
* memcard*.mcrを書き出す
* saveDataを書き戻す
