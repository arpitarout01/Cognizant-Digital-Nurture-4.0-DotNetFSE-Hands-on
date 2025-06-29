-- Exercise 1 : Ranking and Window Functions

-- Step 1 :
SELECT *
FROM (
    SELECT *,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS row_num
    FROM Products
) AS ranked
WHERE row_num <= 3;

-- Step 2:
SELECT *
FROM (
    SELECT *,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS rank_num
    FROM Products
) AS ranked
WHERE rank_num <= 3;

-- Step 3:
SELECT *
FROM (
    SELECT *,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS dense_rank_num
    FROM Products
) AS ranked
WHERE dense_rank_num <= 3;
