   M S B A M L   `   `   `  ����  
DIRECTView(    "DIRECTView.Controls.Ribbons.Ribbon   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      c _DevExpress.Xpf.Ribbon.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5	      .��5      � .+�5   
   )  #DevExpress.Xpf.Ribbon.RibbonControl      RibbonStyle$  
Office2010=�5         RibbonTitleBarVisibility$ 	Collapsed=�5      %   ToolbarShowCustomizationButton .     ToolbarShowMode$
 Hide=�5      $��16(�63   #   MinimizationButtonVisibility$ 	Collapsed=�6A      ShowApplicationButton .     
Categories. 5      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Pages. 5      &   DevExpress.Xpf.Ribbon.RibbonPage  -   5          Name$ 
RibbonPage��5   !   	   Caption)  #DevExpress.Xpf.Core.ObjectConverter$	 Performance Measures 65   
   Groups.
 5      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup  -   5          Name$ TravelTimesGroup��5   *      Caption$ Travel Times��5   *      Items. 5      &   DevExpress.Xpf.Bars.BarCheckItem  -   5          Name$ TravelTime__EntireSystem��5   +   !  DevExpress.Xpf.Bars.BarItem   Content$ Entire System 5   +      	IsChecked$
 TrueY�5   +      AllowUncheckInGroup .    GlyphAlignment$ Bottom=�5   +      	GlyphSize$ Large=�5   +      Glyph 5   +   *	  $DevExpress.Xpf.Core.DXImageExtension	   	  Image1
  +DevExpress.Xpf.Core.Native.DXImageConverter$ HistoryItem_16x16.png
    
LargeGlyph 5   +   	  $ HistoryItem_32x32.png
 5   +     5      -   5        $  TravelTime__US75Northbound��5   +   $ US 75 Northbound 5   +    . $ Bottom=�5"   +   $ Large=�5$   +    5    +   	  $ HistoryItem_16x16.png
  5#   +   	  $ HistoryItem_32x32.png
 5$   +     5&      -   5        $  TravelTime__US75Southbound��5&   +   $ US 75 Southbound 5'   +    . $ Bottom=�5*   +   $ Large=�5,   +    5(   +   	  $ HistoryItem_16x16.png
  5+   +   	  $ HistoryItem_32x32.png
 5,   +   5-        5/      -   5        $ EnvironmentGroup��5/   *   $ Environment��50   *   . 51        -   5        $ B1��51   +   $ Large=�54   +      	IsVisible .   52   +   	  $" GradientRedDataBar_16x16.png
  53   +   	  $" GradientRedDataBar_32x32.png
 55   +     56      -   5        $ B2��56   +   $ Large=�59   +    .   57   +   	  $% GradientOrangeDataBar_16x16.png
  58   +   	  $# GradientBlueDataBar_32x32.png
 5:   +     5;      -	   5        $ FuelConsumption��5;   +   $ Fuel Consumption 5<   +   $ Large=�5?   +    . $ Bottom=�5A   +    5=   +   	  $&  FilterByArgument_Chart_16x16.png
  5>   +   	  $&  FilterByArgument_Chart_32x32.png
 5A   +     5B      -
   5        $ CarbonDioxide��5B   +   $ Carbon Dioxide 5C   +    . $ Bottom=�5F   +   $ Large=�5H   +    5D   +   	  $ NewFeed_16x16.png
  5G   +   	  $ NewFeed_32x32.png
 5H   +     5I      -   5        $ NitrogenOxide��5I   +   $ Nitrogen Oxide 5J   +    . $ Bottom=�5M   +   $ Large=�5O   +    5K   +   	  $ Feeds_16x16.png
  5N   +   	  $ Feeds_32x32.png
 5O   +   5P        5Q      -   5        $# US75NorthboundRibbonPageGroup��5Q   *   $" US 75 Northbound ScreenLines��5R   *     5S      -   5        $# US75SouthboundRibbonPageGroup��5S   *   $" US 75 Southbound ScreenLines��5T   *   5U      5V      5W      5X      5Y      