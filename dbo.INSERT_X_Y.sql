CREATE PROCEDURE INSERT_X_Y
@X_Value int,
@Y_Value int
AS
INSERT INTO X(X_VALUE) values(@X_Value);
INSERT INTO Y(Y_VALUE) values(@Y_Value);