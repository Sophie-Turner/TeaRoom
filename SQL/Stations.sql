CREATE TABLE Stations 
(
    stationId INT NOT NULL,
    stationName VARCHAR(30)
    CONSTRAINT pk_Stations PRIMARY KEY (stationId)
);

INSERT INTO Stations(stationId, stationName)
VALUES 
(1, 'Blaenau Ffestiniog'),
(2, 'Tanygrisiau'),
(3, 'Dduallt'),
(4, 'Tanybwlch');

