   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5       
DIRECTView&    DIRECTView.Controls.Charts.Chart   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _DevExpress.Xpf.Charts.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aACharts4http://schemas.devexpress.com/winfx/2008/xaml/charts  5      3System&clr-namespace:System;assembly=mscorlib  5      (  "DevExpress.Xpf.Charts.ChartControl    ToolTipEnabled$
  TrueX�5         CrosshairEnabled$
 TrueX�5      $��Center=�5         AnimationMode$ OnDataChanged=�5         CrosshairOptions 5      ,  &DevExpress.Xpf.Charts.CrosshairOptions  5   
      ArgumentLineBrush �	#FFF51B1B   GroupHeaderPattern$ {A:h:mm tt}��5   "      ValueLineStyle 5      %  DevExpress.Xpf.Charts.LineStyle  5      5         Palette 5      )  #DevExpress.Xpf.Charts.CustomPalette  5   
      Colors 5      ��5      	#FF5B9BD5��6#   ��5      	#FFED7D31��6#   ��5      	#FFA5A5A5��6#   ��5      	#FFFFC000��6#   ��5      	#FF4472C4��6#   ��5      	#FF70AD47��6#   ��5       	#FF264478��6#   ��5!      	#FF9E480E��6#   ��5"      	#FFBC8C00��6#   ��5#      	#FF35591D��6#   ��5$      	#FFB7B7B7��6#   ��5%      	#FFC4D5EB��6#   ��5&      	#FFA349A4��6#   ��5'      	#FFB97A57��6#   ��5(      	#FF7092BE��6#   ��5)      	#FFEFE4B0��6#   ��5*      	#FF3F48CC��6#   ��5+      	#FF7F7F7F��6#   ��5,      	#FFED1C24��6#   ��5-      	#FF798CAB��6#   ��5.      	#FF293955��6#   ��5/      	#FF0202FF��6#   ��50      MediumOrchid��6&   ��51      	#FFFEF683��6#   53      	   ToolTipOptions	 55      *  $DevExpress.Xpf.Charts.ToolTipOptions  56   
   
   ShowForSeries
 . 6       Legend 58      "  DevExpress.Xpf.Charts.Legend  59   
      HorizontalPosition$ Center=�6      VerticalPosition$ BottomOutside=�5:         Orientation$ 
Horizontal=�5;         Visible$
 TrueX�5<       � Cursor$
 None��5=         IndentFromDiagram$ 5q�5>         Diagram. 5@      '  !DevExpress.Xpf.Charts.XYDiagram2D  -   5          Name$ XYDiagram2D��5@      #  DevExpress.Xpf.Charts.Diagram   SeriesDataMember$
 Name��5A      &	   System.Windows.Media.TextOptions 	  TextHintingMode$ Animated=�5B       	  TextFormattingMode$ Display=�5C         AxisX 5D   
   #
  DevExpress.Xpf.Charts.AxisX2D
  5E      "  DevExpress.Xpf.Charts.Axis2D   Visible$
 TrueX�6    
  DateTimeScaleOptions 5F      6  0DevExpress.Xpf.Charts.ManualDateTimeScaleOptions  5G         MeasureUnit$ Minute=�68      GridAlignment$ Minute=�5H   8      DevExpress.Xpf.Charts.Axis   Title 5J      %  DevExpress.Xpf.Charts.AxisTitle  5K      -   5          Name$ 
XAxisTitle��5K   '   %  DevExpress.Xpf.Charts.TitleBase   Content$
 Time��5L   '   $��14(�5M   '   $
��Bold"�5N   '   $��Tahoma)�5O   '   $  DevExpress.Xpf.Charts.AxisBase   Label 5Q      %  DevExpress.Xpf.Charts.AxisLabel  5R          Angle$	  270��6'   $��2q�5S   '   !   TextPattern$! 	{A:HH:mm}��5T   '    "   ResolveOverlappingOptions" 5V      >  8DevExpress.Xpf.Charts.AxisLabelResolveOverlappingOptions  5W      5Y      #   ConstantLinesInFront# 5[      (  "DevExpress.Xpf.Charts.ConstantLine  5\      -   5        $  Name$ $ EndOfTrafficManagementLine��5_   *   $
��Bold"�5]   *   $��14(�5^   *   %   Brush
% �   �&   
LegendText& 5\   *   Z� '   Value' 5a      i�5b      18:05:00h�68   (   	LineStyle( 5d        5e      )   DashCap$) Triangle=�6/   *   	Thickness$* 5��5f   /   +   LineJoin$+ Bevel=�5g   /   ,   Title, 5i      -  'DevExpress.Xpf.Charts.ConstantLineTitle  5j      $ End of Traffic Management��67   -   ShowBelowLine- . .   	Alignment$	. Far=�5l   7   5o      5q      /   AxisY/ 5s   
   #  DevExpress.Xpf.Charts.AxisY2D  5t      0   GridLinesMinorVisible0 .  1   Brush1 �	#FF0909822   NumericScaleOptions2 5v      Z�  3   CrosshairAxisLabelOptions3 5w      5  /DevExpress.Xpf.Charts.CrosshairAxisLabelOptions  5x      4   
FontWeight$
4 Bold"�67   5   FontSize$5 20Q�5y   7   6   
Visibility$
6 TrueX�5z   7    5|        5}      -   5        $ 
YAxisTitle��5}   '   $, &Percentage Saving in Total Travel Time��5~   '   $��14(�5   '   $
��Bold"�5�   '   $��Tahoma)�5�   '    5�        5�      -   5        7  Name$7 
YAxisLabel��5�   '   $��0q�5�   '   $��2q�5�   '   $! {V:#,#}��5�   '   " 5�        5�      5�      5�      8   SecondaryAxesY8 5�   
   ,  &DevExpress.Xpf.Charts.SecondaryAxisY2D  5�      0 .  1 �	#FF0909822 5�   &   Z� 3 5�        5�      $
4 Bold"�67   $5 20Q�5�   7   $
6 TrueX�5�   7    5�        5�      -   5        $ YSecondaryAxisTitle��5�   '   $! Total Travel Time (Minutes)��5�   '   $��14(�5�   '   $
��Bold"�5�   '   $��Tahoma)�5�   '    5�        5�      $��0q�6'   $��2q�5�   '   $! {V:#,#}��5�   '   " 5�        5�      5�      5�      5�      5�      