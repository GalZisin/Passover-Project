INSERT INTO Results (X_VAL, OP, Y_VAL)
SELECT  x.X_VALUE, o.Operation, y.Y_VALUE FROM (X as x CROSS JOIN Operation as o CROSS JOIN Y as y)




X as x CROSS JOIN Operation as o CROSS JOIN Y as y;