   M S B A M L   `   `   `  ????G  CLabypassword, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LabypasswordLabypassword  5          Labypassword.ShowPassword   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Labypassword     5        ? 	Resources  5	       ?? 
TargetType   FocusVisual ?? Property ?? Value J? SnapsToDevicePixels ?? StrokeDashArray  Button.Static.Background ?? Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButon ?? 
TargetType ??Name	 ?? CornerRadius
 ??Name ?? Triggers P? Property P? Value ?? 
TargetName 
 Usname 	 uSLog    Labypassword.Passconverter  passconv%   Labypassword.PassconverterColor  	colorconv??%S  'm?       &	  !     &	 ?     &	 ?     &	     &	 4    &	 W    &	 z    &	 ?    &	 ?    &		 ?    &	
     7   7  7  7  7  7  7  7  7  7 	 &	 ?    &	     &	 e    &	 x    ?? 5
   
   " m?6   5      ?? 5   
   .?5      ??  ? ?? 5      ?? 5      .R?5      ?? $??2q?6$    . #??? ??6J   $??1??6?   $	 1 2R?6?   5      5      5      ?? 5   
   $ 	#FFDDDDDC??6;   ?? 5   
   $ 	#FF707070??67   ?? 5   
   $ 	#FFBEE6FD??6>   ?? 5   
   $ 	#FF3C7FB1??6:   ?? 5   
   $ 	#FFC4E5F6??6<   ?? 5   
   $ 	#FF2C628B??68   ?? 5   
   $ 	#FFF4F4F4??6=   ?? 5   
   $ 	#FFADB2B5??69   ?? 5   
   $ 	#FF838383??6=   ?? 5    
   " ??6%   .?5!      ??  ?@?FocusVisualStyle8   61   ?? 5"       ? ??8  6+   ?? 5#       ? ??8  6,   ?? 5$       ? ??# ? ??6+   ?? 5%       ? ??$ 1q?60   ?? 5&       ? ??$ Center=?6;   ?? 5'       ? ??$ Center=?69   ?? 5(       ? ??$ 1q?6(   ?? 5)       ? ?? 5*      ?? 5+      " ??6&   .R?5,      ?? $ border??6!   $	 10??61   #??z??6C   #??z??6o   #??z??6?    . ._?5-      ?? $
 contentPresenter??6/   |?.  #??z??6[   #??z??6?   ??. # z 6?   #??z??6  5.       5/      P? 50       ?@??IsDefaulted . . ?51   "   ?? $ border??6@   # ? ??6T    ? ??52      P? 53       ?@J?IsMouseOver . . ?54   "   ?? $ border??6?   8   ? ??6S   ?? 55   "   $ border??6@   8   ? ??6T   56      P? 57       ? ?? . . ?58   "   ?? $ border??6?   8   ? ??6S   ?? 59   "   $ border??6@   8   ? ??6T   5:      P? 5;       ? {? .  . ?5<   "   ?? $ border??6?   8   ? ??6S   ?? 5=   "   $ border??6@   8   ? ??6T   ?? 5>   "   $ contentPresenter??6K   8 	  ? ??6i   5?      5A      5C      5D      ?? 5E   
   " ??6   .?5F      ??  ? ??$ 17(?6)   5G      ?? 5H   
   " ??6   .?5I      ??  ? ??$ 10(?6)   5J        5K   
   6     5L   
   6#   5M      .??5N      ? .+?5O   
   ?  ? RowDefinitions 5P      ?? 5Q      $??* ?6    ?? 5R      $??35??6    $??35??6/   .+?5T      ?? $
??Auto=?6   .??5i      ? $??0??6    5j      ?? 5k      $??90 ?6(   ?? 5l      $??50 ?6(   ?? 5m      $??50 ?6(   ?? 5n      $??50 ?6(   ?? 5o      $??55 ?6(   ?? 5p      $??60 ?6(   ?? 5q      $??30 ?6(   ?? 5r      $??30 ?6(    ? ColumnDefinitions 5t      ?? 5u      $??90 ?6+   ?? 5v      $??* ?6+   .+?5x      ?? $??1??6    $??0??6-   $??Email??6=   $??Center=?6J   $??Right=?6e   ?? 5y      $??2??6    $??0??6-   $??Login??6=   $??Center=?6J   $??Right=?6e   ?? 5z      $??3??6    $??0??6-   $??Website??6=   $??Center=?6L   $??Right=?6g   ?? 5{      $??4??6    $??0??6-   $??Password??6=   $	??Top=?6M   $??Right=?6e   $??0,10,0,0q?6?   ?? 5|      $??5??6    $??0??6-   $
??Noes??6=   $??Center=?6I   $??Right=?6d   ?? 5}      $??6??6    $??0??6-   $??Creation Time??6=   $??Center=?6R   $??Right=?6m   ?? 5~      $??7??6    $??0??6-   $??Last Edit Time??6=   $??Center=?6S   $??Right=?6n   ? 5      $??1??6   $??0??6+    5?      ?? 5?      $??70??6/   $??70??6=   ?? 5?      $??* ?6/   .+?5?      ?? -   5         ??Name$ ShowIcon??5?   7   $??60??6    $??50??6+   ??6I   ?? *icon+?? 5?      -   5         ??Name$ NameBox??5?   $   $	??140??6K   $??30??6W   $??1??6c   $
??Left=?6s   #??[ 6?   ??65   ?? *Name+6?   5?      ]? 5?      $??	15,8,15,8q?6    $??1??63   $??1??6C   .+?5?      ?  5?      ?? 5?   "   $??* ?63   $	??120??6=   ?? 5?   "   $??60 ?63   .+?5?      ?? ?? 5?      -   5        .?5?   9   .?5?   "   ?? -   5        $ mailbox??5?   ,   ??6=   ?? *Email+5?      5?      ?? 5?      -   5         ??Name$ Coppy1??5?   1   $??20??6%   $??4q?6A   $??1??6L   $
??Copy??6\   #??? 
 6k   6?   5?      5?      ]? 5?      $??	15,8,15,8q?6    $??1??63   $??2??6C   .+?5?      ?  5?      ?? 5?   "   $??* ?63   $	??120??6=   ?? 5?   "   $??60 ?63   .+?5?      ?? -   5        $ 	loginbox2??5?   (   ??6;   ?? *Login+?? 5?      -   5        $ Coppy2??5?   1   $??20??6%   $??4q?6A   $??1??6L   $
??Copy??6\   #??? 
 6k   6?   5?      5?      ]? 5?      $??	15,8,15,8q?6    $??1??63   $??3??6C   .+?5?      ?  5?      ?? 5?   "   $??* ?63   $	??120??6=   ?? 5?   "   $??60 ?63   .+?5?      ?? ?? 5?   "   -   5        .?5?   <   .?5?   &   ?? -	   5        $ webbox??5?   j   $??Stretch=?60   $??Stretch=?6N   $	??Top=?6z   ??6?   ?? *	Website+5?      5?      ?? 5?      -
   5        $ Coppy3??5?   1   $??20??6%   $??4q?6A   $??1??6L   $
??Copy??6\   #??? 
 6k   6?   5?      5?      ]? 5?      $??	15,8,15,8q?6    $??1??63   $??4??6C   .+?5?      ?  5?      ?? 5?   "   $??* ?60   ?? 5?   "   $??* ?60   .+?5?      G? -   5         G?Name$ passbox??5?   W   $??0q?6*   
?????? 6W   ? 5?      -   5         ?Name$ progbar??5?   *   $??1??6;   $??4q?6H    ? Minimum$ 0Q?6S    ? Maximum$ 5Q?6_    ? Value 6k   ??  ?? ElementName$ passlab?? ?? Path$ Content? ?? Mode$ OneWay=? ?? 	Converter# [  ?? UpdateSourceTrigger$ PropertyChanged=???5?   *   ?? $ passlab??$ Content?$ OneWay=?# [ $ PropertyChanged=?5?      5?      ]? 5?      $??	15,8,15,8q?6    $??1??63   $??5??6C   .+?5?      ?? -   5        $ notebox??5?   $   ??65   ?? *Notes+5?      ]? 5?      $??	15,8,15,8q?6    $??1??63   $??6??6C   .+?5?      ?? -   5        $ lasted??5?   $   $??Center=?64   $??Center=?6O   5?      ]? 5?      $??	15,8,15,8q?6    $??1??63   $??7??6C   .+?5?      ?? -   5        $ creatim??5?   $   $??Center=?65   $??Center=?6P   5?      5?      5?      ? 5?      $??3??6   
???????.+?5?      ? $??Right=?6    5?      ?? 5?      $??1 ?6+   ?? 5?      $??60 ?6+   ?? 5?      $??60 ?6+   .+?5?      ?? -   5        $??passlab??5?      $y?Hidden=?6+   ??6?   ?? *
Password+?? 5?      -   5        $ 
EditButton??5?      $??4q?61   $??1??6<   $
??Edit??6L   #??? 
 6[   6?   ?? 5?      -   5        $ Delete??5?      $??4q?6-   $??2??68   $??Delete??6H   #??? 
 6Y   6?   5?      5?      5?      5?      5?      