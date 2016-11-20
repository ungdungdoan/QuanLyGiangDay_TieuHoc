CREATE FUNCTION dbo.TaoMaLopMoi(@namhoc NUMERIC, @khoilop NUMERIC) RETURNS VARCHAR(20)
AS
BEGIN
		DECLARE @ketqua VARCHAR(20)
		DECLARE @khoi VARCHAR(5)
		DECLARE @nam VARCHAR(5)		
		DECLARE @stt_max VARCHAR(5)

		SET @khoi = ( SELECT CONVERT(CHAR(2),@khoilop) )
		SET @nam  = ( SELECT RIGHT(CONVERT(CHAR(4),@namhoc),2) )
		
		IF ( ( SELECT COUNT(*) FROM lop 
			   WHERE @khoi=SUBSTRING(malop,3,2) AND @nam=SUBSTRING(malop,5,2) ) = 0 )
			BEGIN
				 SET @stt_max = '01'			 	
			END
		ELSE
			BEGIN				 
				 SET @stt_max = (SELECT CONVERT(CHAR(2),MAX(RIGHT(malop,2))+1) 
								 FROM lop 
								 WHERE @khoi=SUBSTRING(malop,3,2) 
									   AND @nam=SUBSTRING(malop,5,2))

				 IF LEN(@stt_max) = 1
					BEGIN
						SET @stt_max = '0' + @stt_max
					END				 
			END

		SET @ketqua = 'LH' + @khoi + RIGHT(@nam,2) + @stt_max

		RETURN (@ketqua)
END;
GO


CREATE FUNCTION dbo.TaoMaHocSinhMoi(@malophoc VARCHAR(20)) RETURNS VARCHAR(20)
AS
BEGIN
		DECLARE @ketqua VARCHAR(20)
		DECLARE @stt_max VARCHAR(5)

		IF (( SELECT COUNT(*) FROM hocsinh WHERE @malophoc = SUBSTRING(mahs,3,8)) = 0)
			BEGIN
				SET @stt_max = '01'
			END
		ELSE
			BEGIN
				SET @stt_max = (SELECT CONVERT(CHAR(2),(MAX(RIGHT(mahs,2))+1)) FROM hocsinh WHERE @malophoc=SUBSTRING(mahs,3,8))

				IF LEN(@stt_max) = 1
					BEGIN
						SET @stt_max = '0' + @stt_max
					END				
			END

		SET @ketqua = 'HS' + @malophoc + @stt_max

		RETURN @ketqua

END;
GO
