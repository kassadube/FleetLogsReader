﻿select COUNT(*) from LogTBL where LogType = 'DBTrace'
select COUNT(*) from LogTBL where LogType = 'Trace'
select * from LogTBL where LogType = 'DBTrace' and Trace > '00:00:05' order by Trace desc
select * from LogTBL where LogType <> 'DBTrace'
select * from LogTBL where LogType = 'Trace' and Message > '00:00:10'  order by Message desc

select * from LogTBL where LogType = 'Warn' order by InsertDate 

select COUNT(*) from LogTBL where LogType = 'Error'

