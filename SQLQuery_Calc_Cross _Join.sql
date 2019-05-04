INSERT INTO Results (X_VALUE, OPERATION, Y_VALUE)
SELECT  x.X_VALUE, o.Operation, y.Y_VALUE 
FROM (X as x CROSS JOIN Operation as o CROSS JOIN Y as y)




