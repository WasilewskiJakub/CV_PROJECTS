   M S B A M L   `   `   `  ����G  CLabypassword, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LabypasswordLabypassword  5          Labypassword.MainP   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Labypassword     5      $��14(�5   7     � 	Resources  5	      ��%    5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   o� $��0��6   ��5      �� 5      .R�5      ]� $��Right=�6    5      .@�5      m� -   5        $��Logout��5      6=   m� 5      $
��Save��6   6'   5      � 5    
   $��1��6    5!      �� 5"      $��* �6#   �� 5#      $��4* �6#   .+�5%      R� -   5        $��manager��5%   '   $��0��6   ��66   �� *
TreeData+  5/         
EmptySpace  
FolderMenu  PasswordMenu  ImgMenu'   !Labypassword.ContextMenuConverter  ContextMenuConverter   
EmptySpace   
FolderMenu   PasswordMenu   ImgMenu �� 
TargetType �� Property	 �� Value
 �� 	Converter��%7  &	        &	 �     &	 �    &	 >    &	 �    7   7  7  7  'Q�     7  'R� �    7  �� 50      .@�51      m� -   5        $��Add Directory��51   #   6:   m� 52      $��Add File��6#   .@�53      m� -   5        $��Password��53   '   69   m� 54      -   5        $��Image��54   '   66   55      56      �� 57      .@�58      m� {�.  ��6#   �� *Name+6;   �� 59      m� 5:      -   5        $��Add Directory��5:   #   6:   m� 5;      $��Add File��6#   .@�5<      m� -   5        $��Password��5<   '   69   m� 5=      -   5        $��Image��5=   '   66   5>      �� 5?      m� 5@      $��Rename��6#   m� 5A      -	   5        $��Delete��5A   #   63   5B      �� 5C      .@�5D      m� {�.  ��6#   �� *Name+6;   �� 5E      m� 5F      $��Rename��6#   m� 5G      -
   5        $��Delete��5G   #   63   5H      �� 5I      .@�5J      m� {�.  ��6#   �� *Name+6;   �� 5K      m� 5L      $��Rename��6#   m� 5M      -   5        $��Delete��5M   #   63   5N        5O      8   8  8  8  5S   -   �� 5U      " Q�6   .�5V      ��  �@�ContextMenu	 68   �� 8
   -   5        5Y      �� 5Z      " R�6   .�5[      ��  �@�ContextMenu	 68   �� 8
   5]      5^      ��5m      �� 5n       �� DataType   Labypassword.INode"  6P    �� ItemsSource 6/   �� *
Children+.R�5q      �� $
��Node��6$   ��60   �� *Name+ �� Triggers 5u      �� 5v   "    �� Value$
 True��6F    �� Binding 6.   �� *Dir+.a�5w   "   ��  �� 
TargetName$
 Node��6)    � ��$
	 Bold"�6Q   5y      �� 5z   #   $ False��6G    6/   �� *Dir+.a�5{   "   �� $
 Node��6)    � ��$	 Italic$�6P   5|   #   5~      5�       � 5�      -   5          �Name$ frameforinfo��5�      $��1��6*     � NavigationUIVisibility$ Hidden=�6:   5�      5�      5�      