   M S B A M L   `   `   `  ????I  EUIKitTutorials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UIKitTutorialsUIKitTutorials  5   	   !    UIKitTutorials.CustomerMain   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:UIKitTutorials     5   	   -   5        $
??home??5        ? Title$  
MainWindow??5   	   $	??650??6   $
??1000??6)    ? WindowStartupLocation$ CenterScreen=?5	   	    ? WindowStyle$
 None=?6.   
??????  ? AllowsTransparency .  ? 
ResizeMode$ NoResize=?5   	    ? WindowState$ Normal=?6   .??5      ??  ?? CornerRadius$ 8??6      PrimaryBackgroundColor#???   6   ._?5   
   ? -   5         ? ColumnDefinitions 5      ?? 5      $
??Auto ?6#   ?? 5      .+?5      ?? $ 8 0 0 8??6     SecundaryBackgroundColor#???  6,   ._?5      ? -   5         ?Name$ gridMenu??5      $??60??6)   	 ? RowDefinitions	 5      ?? 5      $??60 ?6(   ?? 5      $??80 ?6(   ?? 5      $
??Auto ?6(   ?? 5      .+?5      ?? $??1??6!   
 ?? Orientation$
 
Horizontal=?6.   $	??Top=?6G   d? 5       -   5         d?Name$ btnMenu??5    #   $??Right=?65   $??0q?6Q   
?????? $??Center=?6~     MenuIconStyle#??[ 6?   $??0 0 15 0q?6?    ? Triggers 5!      :? 5"       :? RoutedEvent$ ToggleButton.Unchecked??6+   .[?5#   "   ?? .??5$   &   ?? -   5         ??Name$ HideStackPanel??5$   1   .??5%   *   W?  ?? 
TargetName$ gridMenu??6:    ?? TargetProperty$ Width?6[    g? 	BeginTime$ 0:0:0X?6}    W? From$	 200X?6?   	 W? To$ 60X?6?    g? Duration$ 0:0:0.3D?6?   5&   +   5'   '   5(   #   5)      :? 5*      $ ToggleButton.Checked??6+   .[?5+   "   ?? .??5,   &   ?? -   5        $ ShowStackPanel??5,   1   .??5-   *   W? $ gridMenu??6:   $ Width?6[   $ 0:0:0X?6}   $ 60X?6?   $	 200X?6?   $ 0:0:0.3D?6?   5.   +   5/   '   50   #   51      53      ?? 55      $??3??6!   .+?56      	? -   5         	?Name$ rdHome??56   &    d? 	IsChecked$
 TrueY?66   $
??Home??6G     MenuRadioButtonStyle#???  6V     home
 ? Tag# ?  6?   6?   	? 57      -   5        $ rdSounds??57   &   $??Service History??68   #???  6R     
headphones# ?  6?   $??0 5 0 5q?6?   6?   58      ?? 5:      $??3??6!   $??Bottom=?6.   $
 
Horizontal=?6I   $	??200??6b   $??0 0 0 20q?6n   .+?5;      A? $??40??6"   $??40??6-   $??10 0 0 0q?69   ??5<      ?? 5=   "    ?? ImageSource$ prof.png??6-    j? Stretch$ Uniform=?6D   5?      ?? 5@      $
 Vertical=?6%   $??8 0 0 0q?6<   .+?5A      ?? $??Scarlett Gwen??6$     TextPrimaryColor#???  6<   $??14(?6l   $??SemiBold"?6z   $??Center=?6?   $
??Left=?6?   ?? 5B      $??scarlettgwen@gmail.com??6$     PrimaryGrayColor#???  6E   $??11(?6u   $??Regular"?6?   $??Center=?6?   $
??Left=?6?   $??	0 -10 0 0q?6?   5C      5D      5E      5F      ? 5J      $??1??6   $??0,2,0,-2q?6#   ???	#FFDEDEDE	 5K      ?? 5L      $??60 ?6$   ?? 5M      .+?5Q      ?? $
??Left=?6   $??45??67   $??10,10.335,0,0q?6C   $	??Top=?6Z   $??132.667??6r   ??5R      ?? 5S      $ MESR Motors.png??6%   $ UniformToFill=?6C   5U      ?? 5X      $??0??6   $??4??6*   $??Right=?6:   $	??Top=?6V   $??0,5,10,0q?6n   $??30??6?   $
 
Horizontal=?6?   $??RightToLeft=?6?   .+?5Y      ?? -	   5         ??Name$ btnClose??5Y        IconButtonsStyle#??[ 6/    		 close#??? 	 6Y   $ IsCloseButton??6?   ?? 5Z      -
   5        $ 
btnRestore??5Z      $	??5,0q?61   ??5[      ?? 5\       ?? 
TargetType" ??6$    ?? BasedOn# [ 6A   .?5]   "   ??  ?? Property ? ?? 
 maximize ?? Value# ? 
 6<    ?? Triggers 5^   "   ?? 5_   &     ?? Binding  62   ?? *WindowState+! ?? ElementName$
! home??" ?? Value" 	Maximized6d   .a?5`   *   ??  ? ??  restore# ?  6D   5a   '   5c      5e      ?? 5f      -   5        $ btnMinimize??5f      #???  62     minimize#???  6]   6?   5g      ?? 5j      $??1??6   $??10q?6&   ._?5k       ? -   5        #  ?Name$# PagesNavigation??5k      $  ? NavigationUIVisibility$$ Hidden=?65   5m      5n      ?? 5o      $	??507??6   $??30??6&   $??Center=?62   $
??Left=?6T   $??
30,16,0,14q?6o     ModernTextbox#??[ 6?   5p      5r      5s      5t      