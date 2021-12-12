## lasso.CollectionGrid
###Slice and dice your collections on a 2-dimensional grid.

The collectionGrid class lets you place a collection of elements
on a virtual 2-dimensional grid, enabling you to easily extract
single or multiple rows or columns of elements. This allows you to
easily draw the grid in a graphical system (like a HTML table).

The collection grid consists of a number of _cells_ in a 1-based
coordinate system. The grid can be either _horizontal_
(placing elements from left to right) or _vertical_
(placing elements from top to bottom).

Here are some examples using a simple collection
of characters ('A', 'B', 'C', 'D', and 'E').

Using a _horizontal_ grid with three columns will give you:

(1, 1) => 'A'&nbsp;&nbsp;&nbsp;&nbsp;(1, 2) => 'B'&nbsp;&nbsp;&nbsp;&nbsp;(1, 3) => 'C' \
(2, 1) => 'D'&nbsp;&nbsp;&nbsp;&nbsp;(2, 2) => 'E'

Using a _vertical_ grid with three columns will give you:

(1, 1) => 'A'&nbsp;&nbsp;&nbsp;&nbsp;(1, 2) => 'C'&nbsp;&nbsp;&nbsp;&nbsp;(1, 3) => 'E' \
(2, 1) => 'B'&nbsp;&nbsp;&nbsp;&nbsp;(2, 2) => 'D'
