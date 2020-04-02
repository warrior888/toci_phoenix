drop table GeographicRegions;

create table GeographicRegions
(
	Id integer identity primary key,
	IdGeographicRegions integer references GeographicRegions(Id),
	Name text
);