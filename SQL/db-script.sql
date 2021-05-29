DROP TABLE [PORT], [TRIP], [TRIPSEGMENT]

CREATE TABLE [dbo].[Port]
(
	[PortId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL 
)

CREATE TABLE [dbo].[Trip] (
    [TripId]     INT          IDENTITY (1, 1) NOT NULL,
    [TripNumber] VARCHAR (50) NOT NULL,
    [VesselName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([TripId] ASC)
);

CREATE TABLE [dbo].[TripSegment]
(
	[TripSegmentId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TripId] INT NOT NULL,
	[StartPortId] INT NOT NULL,
	[EndPortId] INT NOT NULL,
	[SailingSequence] INT NOT NULL,
	[StandardHours] DECIMAL(6,2) NOT NULL,
	[StartDateTime] DateTime NULL,
	[EndDateTime] DateTime NULL, 
    CONSTRAINT [FK_TripSegment_ToTrip] FOREIGN KEY ([TripId]) REFERENCES [Trip]([TripId]),
	CONSTRAINT [FK_TripSegment_ToStartPort] FOREIGN KEY ([StartPortId]) REFERENCES [Port]([PortId]),
	CONSTRAINT [FK_TripSegment_ToEndPort] FOREIGN KEY ([EndPortId]) REFERENCES [Port]([PortId])
)


INSERT INTO Port
VALUES ('Port A'),('Port B'),('Port C'),('Port D'),('Port E'),('Port F'),('Port G')

INSERT INTO Trip
VALUES ('T001', 'VESSEL #1'),('T002', 'VESSEL #1'),('T003', 'VESSEL #2'),('T004', 'VESSEL #2')

select * from trip

TRUNCATE TABLE TripSegment
INSERT INTO TripSegment VALUES 
(1, 1, 2, 1, 12, '2021-03-01 09:00:00', '2021-03-01 21:35:00'),
(1, 2, 3, 2, 8, '2021-03-02 03:00:00', '2021-03-02 13:00:00'),
(2, 3, 2, 1, 7, '2021-03-02 20:00:00', '2021-03-03 03:10:00'),
(2, 2, 4, 2, 15, '2021-03-03 06:00:00', '2021-03-03 23:00:00'),
(3, 3, 5, 1, 9, '2021-03-01 03:00:00', '2021-03-01 12:00:00'),
(3, 5, 3, 2, 13.5, '2021-03-01 16:00:00', '2021-03-02 08:00:00'),
(4, 3, 6, 1, 18, NULL, NULL)

SELECT 
		s.TripNumber, 
		sp.Name as [StartPort], 
		ep.Name as [EndPort], 
		ts.StandardHours, 
		Cast(DateDiff(Hour, ts.StartDateTime, ts.EndDateTime) as decimal(6,2)) as [ActualHours], 
		ts.StartDateTime, 
		ts.EndDateTime
	FROM TripSegment ts
	JOIN Trip s on s.tripId = ts.tripId
	JOIN [Port] sp on ts.StartPortId = sp.PortId
	JOIN [Port] ep on ts.EndPortId = ep.PortId
WHERE TripNumber = 'T001'
ORDER BY s.TripNumber, ts.SailingSequence