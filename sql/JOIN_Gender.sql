SELECT
    g.Name AS GenderName,
    COUNT(p.Id) AS Total
FROM
    dbo.tblT_personal p
LEFT JOIN
    dbo.tblM_gender g ON p.GenderId = g.Id
GROUP BY
    g.Name    
ORDER BY
    Total DESC;