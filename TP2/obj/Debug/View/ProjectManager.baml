   M S B A M L   `   `   `  ����>  :TP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TP2.ViewTP2.View  5   	       TP2.View.ProjectManager   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TP2.View     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Project Manager��5	   	   $	��300��6!   $	��300��6.   .��5
      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   � .+�5      �� .��6   Mudar o nome do projeto:6.   �� 5      -   5        $��ChangeProjectName��5   +   $��5,22,146,42q�6   6F   �� 5      -   5        $��SaveProjectName��5   )   $��
5,53,196,5q�6   .��6V   Gravar6^   �� 5      -   5        $��189,22,10,10q�5      .��6A   Apagar projeto6Q   5      � 5   
   $��1��6   .+�5      �� .��6   " Adicionar utilizador ao projeto:66   �� 5      -   5        $��	UserToAdd��5   +   $��5,22,122,42q�6   6>   �� 5      -   5        $��AddUsers��5   +   $��191,11,10,42q�6   .��6R   	Adicionar6]   5      � 5   
   $��2��6   .+�5      �� .��6   ,*Adicionar tarefa de utilizador ao projeto:6@   �� 5      -   5        $��TarefaContent��5   )   $��	5,22,5,42q�6   6@   �� 5      -   5        $��
170,53,5,0q�5      .��6A   	Adicionar6L   �� 5      -   5        $��UsersProjeto��5   O   $��
5,53,138,0q�6    J� RenderTransformOrigin$ 0.813,0.362&�6+    �� DisplayMemberPath$
 Name��6�   ��6c   ��  �� Path$
 Team�5!      5"      5#      5$      