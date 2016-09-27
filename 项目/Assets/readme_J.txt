============================================================
【タイトル】
NinjaSlasherX サンプルプログラム
2014/10/10 Version 1.00
(C)2014 Kouji Ohno
O-Planning http://o-planning.jp/
============================================================

このサンプルプログラムは、Unity4.5.4で動作します。
（Unity Proライセンスは必要ありません）

NinjaSlasherXについては、iPhone版とAndroid版が遊べます。
  iOS Version App	:
  https://itunes.apple.com/us/app/ninjaslasherx/id917928055
  Android Version App	:
  https://play.google.com/store/apps/details?id=com.OPlanning.NinjaSlasherX


---------------------------------------
※サウンドについて
---------------------------------------
サウンドファイルは、すべてダミーの無音データで収録しています。


---------------------------------------
※フォントについて
---------------------------------------
サンプルプログラムの一部のフォントに関しては、fub工房様の「切絵字」を使用しています。各サンプルプログラムのAssets/Fonts/フォルダに、フォントファイルを収録していますが、fub工房様の許可を得て収録しているものです。
このサンプルプログラムと関係なく、別途、上記のフォントをご使用になられる場合は、下記のサイトをご覧ください。

FUB切絵字
http://www2s.biglobe.ne.jp/~fub/font/kirieji.html

FUB フォントの注意事項
http://www2s.biglobe.ne.jp/~fub/font/font.html

素材集サイト「fub工房」
http://www2s.biglobe.ne.jp/~fub/


=================================
Unity Pro高速化
=================================

Unity Proの機能を使って高速化したNinjaSlasherXのプロジェクトです。
Unity Proでビルドすると、下記の最適化が有効になります。
プログラム部分の高速化については、Unity Freeでも動作します。


---------------------------------
・UnityPROのスプライトのタイト化
・UnityPROのSprite Packerを利用したアトラス化と高速化
・UnityPROのStaticパッチングを利用した高速化

---------------------------------
・プログラムの高速化
　　・Physics2DのRayの高速化
	BaseCharacterController.cs
      　→接地判定のPhysics2D.OverlapPointAllをPhysics2D.OverlapPointNonAllocで高速化
	EnemyMain.cs
      　→カメラ外での接地判定のオフにする
　　・テキストの高速化
	PlayerController.cs

上記の高速化により、全体的に処理落ちがちょっと緩和されます。


---------------------------------------
履歴
---------------------------------------
2014/10/10 Version 1.00 ファーストバージョン
