   M S B A M L   `   `   `  ����  
DIRECTView(    "DIRECTView.Controls.Charts.Filters   5      a ]DevExpress.Xpf.Core.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      j fDevExpress.Xpf.LayoutControl.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _DevExpress.Xpf.NavBar.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5	        � 	Resources  5         BooleanToVisibility��%   &	        �� 5   
   6'   5      .��5      � ���	#FF93B1DD.+�5   
   �� .��5      ]� $	��Top=�6   .+�5      ]� $	��Top=�6   .+�5      &   DevExpress.Xpf.Editors.CheckEdit  -   5          Name$ _Filters��5   $      Content)  #DevExpress.Xpf.Core.ObjectConverter$ Enable Filters 66      	IsChecked$
 TrueY�5   $   $��Center=�5      $��0q�5      $��5,0,0,0q�6*   $��18.667(�6<   $
��Bold"�6N   5   
   5      ]� 5      $	��Top=�6   .+�5      +  %DevExpress.Xpf.LayoutControl.GroupBox  $	��Top=�6$   4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$ Scenarios Filters��5         
ShowShadow$ WhenHasMouse=�5         MinimizationDirection$ Vertical=�5           MinimizeElementVisibility$ Visible=�5!      ,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5"      ]� .+�5#        $	��Top=�6-   $ Operational Conditions��5$      $ WhenHasMouse=�5%      $ Vertical=�5&      $ Visible=�5'      . 5(   "   ]� .+�5)   &     -   5        $
 OC_1��5*   
   $
 OC-1 5)   4   $
 TrueY�5-   
   �� 5.   &   $��10��60     5/   &   -   5        $
 OC_2��50   
   $
 OC-2 5/   4   $
 TrueY�53   
   �� 54   &   $��10��60     55   &   -   5        $
 OC_3��56   
   $
 OC-3 55   4   $
 TrueY�59   
   �� 5:   &   $��10��60     5;   &   -   5        $
 OC_4��5<   
   $
 OC-4 5;   4   $
 TrueY�5?   
   5@   #   5A        5C      $	��Top=�6,   $ ATDM Strategies��5D      $ WhenHasMouse=�5E      $ Vertical=�5F      $ Visible=�5G      . 5H   "   ]� .+�5I   &     -   5        $ DynamicShoulderLanes��5J   
   $ Dynamic Shoulder Lanes 5I   4   $	��Top=�5M   
   $
 TrueY�5N   
     5O   &   -   5        $ AdaptiveRampMetering��5P   
   $ Adaptive Ramp Metering 5O   4   $	��Top=�5S   
   $
 TrueY�5T   
     5U   &   -   5        $ DynamicSignalTiming��5V   
   $ Dynamic Signal Timing 5U   4   $	��Top=�5Y   
   $
 TrueY�5Z   
     5[   &   -	   5        $ DynamicRouting��5\   
   $ Dynamic Routing 5[   4   $	��Top=�5_   
   $
 TrueY�5`   
     5a   &   -
   5        $ DynamicallyPricedParking��5b   
   $ Dynamic Parking Pricing 5a   4   $	��Top=�5e   
   $
 TrueY�5f   
   5g   #   5i        5j      $	��Top=�6,   $ Assesment Attributes��5k      $ WhenHasMouse=�5l      $ Vertical=�5m      $ Visible=�5n      . 5o   "   ]� .+�5p   &     $ Demand Prediction Accurcy��64   $	��Top=�5q   
   $ WhenHasMouse=�5r   
   $ Vertical=�5s   
   $ Visible=�5t   
   . 5u   *   ]� .+�5v   .   �� $ ��Error in Demand Prediction��64   $	��Top=�5w      ]� 5x   .   $��Bottom=�68   .+�5y   2     -   5        $1 +ErrorInDemandPrediction_Negative_10_Percent��5z      $
 -10% 5y   @   5|      �� 5}   2   $��5��6<     5~   2   -   5        $1 +ErrorInDemandPrediction_Negative_05_Percent��5      $
 -05% 5~   @   5�      �� 5�   2   $��5��6<     5�   2   -   5        $1 +ErrorInDemandPrediction__________00_Percent��5�      $	 00% 5�   @   $
 TrueY�5�      �� 5�   2   $��5��6<     5�   2   -   5        $1 +ErrorInDemandPrediction_Positive_05_Percent��5�      $	 05% 5�   @   5�      �� 5�   2   $��5��6<     5�   2   -   5        $1 +ErrorInDemandPrediction_Positive_10_Percent��5�      $	 10% 5�   @   5�      5�   /   5�   +   5�   '     5�   &   $  Traffic Management Latency��64   $	��Top=�5�   
   $ WhenHasMouse=�5�   
   $ Vertical=�5�   
   $ Visible=�5�   
   . 5�   *   ]� .+�5�   .     -   5        $) #TrafficManagementLatency_00_Minutes��5�      $ 	0 Minutes 5�   <   $
 TrueY�5�      �� 5�   .   $��5��68     5�   .   -   5        $) #TrafficManagementLatency_05_Minutes��5�      $ 	5 Minutes 5�   <   5�      �� 5�   .   $��5��68     5�   .   -   5        $) #TrafficManagementLatency_10_Minutes��5�      $ 
10 Minutes 5�   <   5�      5�   +   5�   '     5�   &   $ Prediction Horizon��64   $	��Top=�5�   
   $ WhenHasMouse=�5�   
   $ Vertical=�5�   
   $ Visible=�5�   
   . 5�   *   ]� .+�5�   .     -   5        $" PredictionHorizon_15_Minutes��5�      $ 
15 Minutes 5�   <   5�      �� 5�   .   $��5��68     5�   .   -   5        $" PredictionHorizon_30_Minutes��5�      $ 
30 Minutes 5�   <   $
 TrueY�5�      �� 5�   .   $��5��68     5�   .   -   5        $" PredictionHorizon_60_Minutes��5�      $ 
60 Minutes 5�   <   5�      5�   +   5�   '     5�   &   $ Coverage Extension��64   $	��Top=�5�   
   $ WhenHasMouse=�5�   
   $ Vertical=�5�   
   $ Visible=�5�   
   . 5�   *   ]� .+�5�   .     -   5        $&  CoverageExtentVariation_02_Miles��5�      $ 2 Miles 5�   <   5�      �� 5�   .   $��10��68     5�   .   -   5        $&  CoverageExtentVariation_03_Miles��5�      $ 3 Miles 5�   <   $
 TrueY�5�      �� 5�   .   $��10��68     5�   .   -   5        $&  CoverageExtentVariation_04_Miles��5�      $ 4 Miles 5�   <   5�      5�   +   5�   '   5�   #   5�      5�      5�        5�      $	��Top=�6$   $ 	Scenarios��5�      $��5q�5�      $
��Bold"�5�      $ WhenHasMouse=�5�      $ Vertical=�5�      $ Hidden=�5�      . 5�      ]� .+�5�        $	��Top=�6,   $��0q�5�      $��1q�5�      $��16(�5�      $
��Bold"�5�      $
 OC-1��5�      $ WhenHasMouse=�5�      ���	#FFF1FFE0$ Vertical=�5�      $ Visible=�5�      . 5�   "   ]� -   5        	 ]�Name$	 
OC_1_Group��5�   ,   5�        5�      $	��Top=�6,   
   State$
 	Minimized=�5�      $��0q�5�      $��1q�5�      $��16(�5�      $
��Bold"�5�      ���	#FFF1FFE0$
 OC-2��5�      $ WhenHasMouse=�5�      $ Vertical=�5�      $ Visible=�5�      . 5�   "   ]� -   5        $	 
OC_2_Group��5�   ,   5        5     $	��Top=�6,   $
 	Minimized=�5     $��0q�5     $��1q�5     $��16(�5     $
��Bold"�5     ���	#FFF1FFE0$
 OC-3��5     $ WhenHasMouse=�5	     $ Vertical=�5
     $ Visible=�5     . 5  "   ]� -   5        $	 
OC_3_Group��5  ,   5       5     $	��Top=�6,   $
 	Minimized=�5     $��0q�5     $��1q�5     $��16(�5     $
��Bold"�5     ���	#FFF1FFE0$
 OC-4��5     $ WhenHasMouse=�5     $ Vertical=�5     $ Visible=�5     . 5  "   ]� -   5        $	 
OC_4_Group��5  ,   5     )  #DevExpress.Xpf.NavBar.NavBarControl  5        AllowSelectItem .  $��60��5  0      AllowSelectDisabledItem .    View 5  "   '  !DevExpress.Xpf.NavBar.SideBarView  5  &      Groups. 5!  "   '  !DevExpress.Xpf.NavBar.NavBarGroup     Header$	 All 62      NavigationPaneVisible .     Items. 5#  &   &	   DevExpress.Xpf.NavBar.NavBarItem	  -   5         	 Name$ DeSelctAllItem��5#  5    	  Content$ Deselect All Scenarios 5$  
    	  ImageSource 5%  
   *
  $DevExpress.Xpf.Core.DXImageExtension
   
  Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ NewTask_32x32.png 5'  #   5(     5*     5+     5,     ]� 5-     $	��Top=�6   5.     51     52     53     