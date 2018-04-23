
#Application UnboundListViewWin
#Application UnboundListViewWeb

*Action Navigation(Book)

*Action New(Book)
*FillForm
 Title = Test Book

*Action Save and New
*FillForm
 Title = Test Book

*Action Save and New
*FillForm
 Title = Test Book

*Action Save and Close

*Action Navigation(Book)

*Action Show Duplicate Books

*ProcessRecord Duplicates
 Title = Test Book

*CheckFieldValues
 Title = Test Book
 Count = 3
