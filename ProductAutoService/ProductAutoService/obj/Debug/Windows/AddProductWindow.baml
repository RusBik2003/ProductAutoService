   M S B A M L   `   `   `  ����M  IProductAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProductAutoService.WindowsProductAutoService.Windows  5   	   1    +ProductAutoService.Windows.AddProductWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:ProductAutoService.Windows     5   	     � Title$  AddProductWindow��5   	   $	��400��6"   $	��400��6/   $	��400��6;   $	��400��6K   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $2��,Введите название товара��6   64   �� 5   
   $E��?введите путь к картинке для товара��6   $��1��5      6   �� 5   
   -   5        $��btnAddNewProduct��5      $��2��5      $��Добавить��5      5      �� 5   
   -   5         ��Name$ txtAddTitle��5      $��1��5      5      �� 5   
   -   5         ��Name$ 
ImgProduct��5      $��1��5!      $��1��5"      5#      �� 5$   
   -   5         ��Name$ btnAddImage��5$      $��2��5%      $��1��5&      $'��!добавить картинку��5'      5(   -   5*      5+      