SELECT o.[Name], n.[Name]
from [Owner] o
LEFT JOIN Neighborhood n on o.NeighborhoodId = n.Id;

SELECT o.[Name], n.[Name]
from [Owner] o
LEFT JOIN Neighborhood n on o.NeighborhoodId = n.Id
WHERE o.Id = 4;

SELECT [Name]
from Walker
ORDER BY [Name] desc;

SELECT DISTINCT Breed
from Dog;

SELECT d.[Name] as 'Dog Name', o.[Name] as 'Owner Name', n.[Name] as 'Neighborhood Name'
from Dog d
LEFT JOIN [Owner] o on d.OwnerId = o.Id
LEFT JOIN Neighborhood n on o.NeighborhoodId = n.Id;

SELECT COUNT(OwnerId) as 'Dog Count', o.[Name] 
from Dog d
LEFT JOIN [Owner] o on d.OwnerId = o.Id	
GROUP BY OwnerId, o.[Name];

SELECT COUNT(WalkerId) as 'Walker', w.[Name]
from Walks wa
LEFT JOIN Walker w on wa.WalkerId = w.Id
GROUP BY WalkerId, w.[Name];

SELECT COUNT(NeighborhoodId) as 'Neighborhood Walkers Count', n.[Name] as 'Neighborhood Name'
from Walker w
LEFT JOIN Neighborhood n on w.NeighborhoodId = n.Id
GROUP BY NeighborhoodId, n.[Name];

SELECT d.[Name]
from Dog d
LEFT JOIN Walks w on d.Id = w.DogId
WHERE w.Date > '03/12/2020' and w.Date < '03/20/2020';

SELECT d.[Name]
from Dog d
LEFT JOIN Walks w on d.Id = w.DogId
GROUP BY d.[Name]
HAVING COUNT(w.Id) = 0;



