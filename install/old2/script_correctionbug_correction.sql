INSERT INTO VACATION VALUES (1,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (1,2,cast('20150913 14:00' as datetime),cast('20150913 15:30'as datetime));
INSERT INTO VACATION VALUES (1,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (1,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (1,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (2,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (2,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (2,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (2,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (2,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (3,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (3,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (3,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (3,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (3,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (4,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (4,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (4,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (4,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (4,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (5,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (5,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (5,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (5,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (5,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (6,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (6,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (6,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (6,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (6,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
ALTER TABLE [dbo].[ATELIER]  WITH CHECK ADD  CONSTRAINT [FK_ATELIER_1] FOREIGN KEY([IDPARTICIPANTANIMATEUR])
REFERENCES [dbo].[PARTICIPANT] ([ID])
GO
ALTER TABLE [dbo].[ATELIER] CHECK CONSTRAINT [FK_ATELIER_1]
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT]  WITH CHECK ADD  CONSTRAINT [FK_DETAILHEBERGEMENT_1] FOREIGN KEY([CODEHOTEL])
REFERENCES [dbo].[HOTEL] ([CODEHOTEL])
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT] CHECK CONSTRAINT [FK_DETAILHEBERGEMENT_1]
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT]  WITH CHECK ADD  CONSTRAINT [FK_DETAILHEBERGEMENT_2] FOREIGN KEY([IDCATEGORIE])
REFERENCES [dbo].[CATEGORIECHAMBRE] ([ID])
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT] CHECK CONSTRAINT [FK_DETAILHEBERGEMENT_2]
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT]  WITH CHECK ADD  CONSTRAINT [FK_DETAILHEBERGEMENT_3] FOREIGN KEY([IDDATENUITEE])
REFERENCES [dbo].[DATENUITEE] ([ID])
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT] CHECK CONSTRAINT [FK_DETAILHEBERGEMENT_3]
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT]  WITH CHECK ADD  CONSTRAINT [FK_DETAILHEBERGEMENT_4] FOREIGN KEY([IDPARTICIPANT])
REFERENCES [dbo].[PARTICIPANT] ([ID])
GO
ALTER TABLE [dbo].[DETAILHEBERGEMENT] CHECK CONSTRAINT [FK_DETAILHEBERGEMENT_4]
GO
ALTER TABLE [dbo].[ETREPRESENT]  WITH CHECK ADD  CONSTRAINT [FK_ETREPRESENT_1] FOREIGN KEY([IDPARTICIPANT])
REFERENCES [dbo].[PARTICIPANT] ([ID])
GO
ALTER TABLE [dbo].[ETREPRESENT] CHECK CONSTRAINT [FK_ETREPRESENT_1]
GO
ALTER TABLE [dbo].[ETREPRESENT]  WITH CHECK ADD  CONSTRAINT [FK_ETREPRESENT_2] FOREIGN KEY([IDDATEBENEVOLAT])
REFERENCES [dbo].[DATEBENEVOLAT] ([ID])
GO
ALTER TABLE [dbo].[ETREPRESENT] CHECK CONSTRAINT [FK_ETREPRESENT_2]
GO
ALTER TABLE [dbo].[HOTELCHAMBREPRIX]  WITH CHECK ADD FOREIGN KEY([IDCATEGORIECHAMBRE])
REFERENCES [dbo].[CATEGORIECHAMBRE] ([ID])
GO
ALTER TABLE [dbo].[HOTELCHAMBREPRIX]  WITH CHECK ADD FOREIGN KEY([IDHOTEL])
REFERENCES [dbo].[HOTEL] ([CODEHOTEL])
GO
ALTER TABLE [dbo].[INCLUREACCOMPAGNANT]  WITH CHECK ADD  CONSTRAINT [FK_INCLUREACCOMPAGNANT_1] FOREIGN KEY([IDPARTICIPANT])
REFERENCES [dbo].[PARTICIPANT] ([ID])
GO
ALTER TABLE [dbo].[INCLUREACCOMPAGNANT] CHECK CONSTRAINT [FK_INCLUREACCOMPAGNANT_1]
GO
ALTER TABLE [dbo].[INCLUREACCOMPAGNANT]  WITH CHECK ADD  CONSTRAINT [FK_INCLUREACCOMPAGNANT_2] FOREIGN KEY([IDRESTAURATION])
REFERENCES [dbo].[RESTAURATION] ([IDRESTAURATION])
GO
ALTER TABLE [dbo].[INCLUREACCOMPAGNANT] CHECK CONSTRAINT [FK_INCLUREACCOMPAGNANT_2]
GO
ALTER TABLE [dbo].[INSCRIRE]  WITH CHECK ADD  CONSTRAINT [FK_INSCRIRE_1] FOREIGN KEY([IDATELIER])
REFERENCES [dbo].[ATELIER] ([ID])
GO
ALTER TABLE [dbo].[INSCRIRE] CHECK CONSTRAINT [FK_INSCRIRE_1]
GO
ALTER TABLE [dbo].[INSCRIRE]  WITH CHECK ADD  CONSTRAINT [FK_INSCRIRE_2] FOREIGN KEY([IDPARTICIPANT])
REFERENCES [dbo].[PARTICIPANT] ([ID])
GO
ALTER TABLE [dbo].[INSCRIRE] CHECK CONSTRAINT [FK_INSCRIRE_2]
GO
ALTER TABLE [dbo].[PAIEMENT]  WITH CHECK ADD  CONSTRAINT [FK_PAIEMENT_1] FOREIGN KEY([IDPARTICIPANT])
REFERENCES [dbo].[PARTICIPANT] ([ID])
GO
ALTER TABLE [dbo].[PAIEMENT] CHECK CONSTRAINT [FK_PAIEMENT_1]
GO
ALTER TABLE [dbo].[PARTICIPANT]  WITH CHECK ADD  CONSTRAINT [FK_PARTICIPANT_1] FOREIGN KEY([IDATELIERINTERVENANT])
REFERENCES [dbo].[ATELIER] ([ID])
GO
ALTER TABLE [dbo].[PARTICIPANT] CHECK CONSTRAINT [FK_PARTICIPANT_1]
GO
ALTER TABLE [dbo].[PARTICIPANT]  WITH CHECK ADD  CONSTRAINT [FK_PARTICIPANT_2] FOREIGN KEY([IDQUALITELICENCIE])
REFERENCES [dbo].[QUALITE] ([ID])
GO
ALTER TABLE [dbo].[PARTICIPANT] CHECK CONSTRAINT [FK_PARTICIPANT_2]
GO
ALTER TABLE [dbo].[PARTICIPANT]  WITH CHECK ADD  CONSTRAINT [FK_STATUT_1] FOREIGN KEY([IDSTATUT])
REFERENCES [dbo].[STATUT] ([ID])
GO
ALTER TABLE [dbo].[PARTICIPANT] CHECK CONSTRAINT [FK_STATUT_1]
GO
ALTER TABLE [dbo].[PARTICIPER]  WITH CHECK ADD  CONSTRAINT [FK_PARTICIPER_1] FOREIGN KEY([IDATELIER], [IDVACATION])
REFERENCES [dbo].[VACATION] ([IDATELIER], [IDVACATION])
GO
ALTER TABLE [dbo].[PARTICIPER] CHECK CONSTRAINT [FK_PARTICIPER_1]
GO
ALTER TABLE [dbo].[PARTICIPER]  WITH CHECK ADD  CONSTRAINT [FK_PARTICIPER_2] FOREIGN KEY([IDATELIER],[IDPARTICIPANT])
REFERENCES [dbo].[INSCRIRE] ([IDATELIER], [IDPARTICIPANT])
GO
ALTER TABLE [dbo].[PARTICIPER] CHECK CONSTRAINT [FK_PARTICIPER_2]
GO
ALTER TABLE [dbo].[PROPOSER]  WITH CHECK ADD  CONSTRAINT [FK_PROPOSER_1] FOREIGN KEY([CODEHOTEL])
REFERENCES [dbo].[HOTEL] ([CODEHOTEL])
GO
ALTER TABLE [dbo].[PROPOSER] CHECK CONSTRAINT [FK_PROPOSER_1]
GO
ALTER TABLE [dbo].[PROPOSER]  WITH CHECK ADD  CONSTRAINT [FK_PROPOSER_2] FOREIGN KEY([IDCATEGORIE])
REFERENCES [dbo].[CATEGORIECHAMBRE] ([ID])
GO
ALTER TABLE [dbo].[PROPOSER] CHECK CONSTRAINT [FK_PROPOSER_2]
GO
ALTER TABLE [dbo].[THEME]  WITH CHECK ADD  CONSTRAINT [FK_THEME_1] FOREIGN KEY([IDATELIER])
REFERENCES [dbo].[ATELIER] ([ID])
GO
ALTER TABLE [dbo].[THEME] CHECK CONSTRAINT [FK_THEME_1]
GO
ALTER TABLE [dbo].[VACATION]  WITH CHECK ADD  CONSTRAINT [FK_VACATION_1] FOREIGN KEY([IDATELIER])
REFERENCES [dbo].[ATELIER] ([ID])
GO
ALTER TABLE [dbo].[VACATION] CHECK CONSTRAINT [FK_VACATION_1]
GO
