ALTER Table CONTROL

Add UID uniqueidentifier not null ROWGUIDCOL unique default newid()


ALTER Table CONTROL

Add IMAGE2 varbinary(max) FILESTREAM null

UPDATE CONTROL

SET IMAGE2=IMAGE