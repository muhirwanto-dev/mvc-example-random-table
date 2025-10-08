SELECT
    p.Id AS id,
    p.Name AS name,
    p.GenderId AS genderId,
    g.Name AS GenderName,
    p.HobbyId AS hobbyId,
    h.Name AS hobbyName,
    p.Age AS Age
FROM
    dbo.tblT_personal p
LEFT JOIN
    dbo.tblM_gender g ON p.GenderId = g.Id
LEFT JOIN
    dbo.tblM_hobby h ON p.HobbyId = h.Id
ORDER BY
    p.Id;