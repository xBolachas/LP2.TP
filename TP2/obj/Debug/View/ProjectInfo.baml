   M S B A M L   `   `   `  ����>  :TP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TP2.ViewTP2.View  5   	       TP2.View.ProjectInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TP2.View     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Task Manager��5	   	   $��316.667��5
   	   $��570.175��6   .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��Backlog��5   L   $��0,0,0,35q�6   
�������$��5q�68      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Task��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 400 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *
WhatToDo+6b     5      $ 	Developer��6%    . $ 90 6h    68   �� *	User.Name+6h   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $
 Done��6)   69   5      �� 5   
   -   5        $��365,255,20,3q�5      .��6?   	Completed6J   5      5      