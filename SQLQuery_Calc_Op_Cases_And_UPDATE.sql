UPDATE results SET RESULTS = 

    CASE OPERATION
        WHEN '+' THEN X_VALUE + Y_VALUE
        WHEN '-' THEN X_VALUE - Y_VALUE
		WHEN '*' THEN X_VALUE * Y_VALUE
        WHEN '/' THEN (X_VALUE * 1.00) / Y_VALUE
        ELSE NULL
    END 

UPDATE results SET RESULTS = 0

SELECT
    CASE OPERATION
        WHEN '+' THEN X_VALUE + Y_VALUE
        WHEN '-' THEN X_VALUE - Y_VALUE
		WHEN '*' THEN X_VALUE * Y_VALUE
        WHEN '/' THEN (X_VALUE * 1.0) / Y_VALUE
        ELSE NULL
    END AS RESULTS
FROM Results
;