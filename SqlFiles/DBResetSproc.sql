use SeaMonster
go

if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='MosterDBRest')
 drop procedure MosterDBRest
 GO

Create Procedure MosterDBRest AS
begin
delete from Images
delete from PostText
delete from HashtagPost
delete from CategoryPost
delete from Hashtags
delete from Reply
delete from Comment
delete from post 
delete from Categories
DBCC CHECKIDENT (Comment,reseed, 0)
DBCC CHECKIDENT (Reply,reseed, 0)
DBCC CHECKIDENT (Post,reseed, 0)
DBCC CHECKIDENT (Images,reseed, 0)
DBCC CHECKIDENT (Hashtags,reseed, 0)
DBCC CHECKIDENT (PostText,reseed, 0)
DBCC CHECKIDENT (Categories,reseed, 0)

Set Identity_Insert Post On
Insert into Post (PostID, PostTitle, ispublished, DateCreated, DisplayAuthor, DisplayDate, isStatic, isforReview) Values (1,'Hello Fellow Monster Hunters',1, '2017-01-15','Author1','2017-01-14',0,0),(2, 'Cracking the Kraken',1,'2017-02-12','Author1','2017-02-12',0,0),
				(3,'Leviathan Wakes!',1,'2017-03-01','Author2','2017-03-01',0,0), (4,'The Monster of Monterey',1,'2017-04-26','Author3','2017-04-26',0,0),(5,'A History of Hoaxes',0,'2017-05-03','Author4','2017-05-03',0,0),
				(6,'About us',1,'2017-08-01','Author1','2017-08-01',1,0),(7,'Monsters Among Us',0,'2017-09-01','Author3','2017-09-13',0,1),
				(8,'A limited time offer',1,'2017-09-19','Author4','2017-09-20',0,0),(9,'Another limited time offer',1,'2017-10-01','Author4','2017-10-13',0,0)
Set  Identity_Insert Post off
DBCC CHECKIDENT (Post,reseed, 9)

update post set
Expdate='2017-11-01'
where PostID=8

update post set
Expdate='2017-12-01'
where PostID=9

update post set
ToPostDate='2017-11-23'
where PostID=9

Insert into PostText (PostId, PostText) values (1,'&lt;!DOCTYPE html&gt &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys tea cup tack code of conduct hands rope&#39;s end grog blossom brigantine Gold Road Shiver me timbers gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. Furl brig holystone haul wind spike wench Pieces of Eight landlubber or just lubber fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. '),
(2,'&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys tea cup tack code of conduct hands rope&#39;s end grog blossom brigantine Gold Road Shiver me timbers gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko case shot. Dead men tell no tales 
hang the jib ye Jolly Roger bilge water jolly boat sheet jury mast pink landlubber or just lubber.
Lanyard nipper grog aye poop deck reef bilge rat square-rigged spyglass measured fer yer chains.
Coxswain jib lookout bucko strike colors Arr rutters capstan topgallant barque. Lass stern ballast Nelsons 
folly Plate Fleet Admiral of the Black hardtack chase capstan fathom. Killick scuttle grog avast code of conduct 
Spanish Main jack barque bilged on her anchor schooner
Furl brig holystone haul wind spike wench Pieces of Eight landlubber or just lubber fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. '),
(3,'&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys tea cup tack code of conduct hands rope&#39;s end grog gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. '),
(4,'&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko conduct hands rope&#39;s end grog blossom brigantine Gold Road Shiver me timbers gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
Furl brig holystone haul wind spike wench Pieces of Eight landlubber or just lubber fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. '),
(5, '&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Help! I am being held on a boat and forced to write this blog.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at 
the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;'),
(6,'&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko conduct hands rope&#39;s end grog blossom brigantine Gold Road Shiver me timbers gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
Furl brig holystone haul wind spike wench Pieces of Eight landlubber or just lubber fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. '),
(7,'&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys  ennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls  
tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko conduct hands rope&#39;s end grog blossom brigantine Gold Road Shiver me timbers gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
Furl brig holystone haul wind spike wench Pieces of Eight ennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls 
landlubber or just lubber fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. '),
(8,'&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys  ennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls  
tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko conduct hands rope&#39;s end grog blossom brigantine Gold Road Shiver me timbers gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
Furl brig holystone haul wind spike wench Pieces of Eight ennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls 
landlubber or just lubber fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. '),
(9,'&lt;!DOCTYPE html&gt; &lt;html&gt; &lt;head&gt; &lt;/head&gt; &lt;body&gt; &lt;p&gt;categories 
listed here Salmagundi boom gunwalls rope&#39;s end Jack Ketch chase sheet cutlass 
Buccaneer starboard.&lt;a title=&quot;kraken&quot; href=&quot;https://en.wikipedia.org/wiki/Kraken&quot;&gt;&amp;nbsp;Corsair&lt;/a&gt;&amp;nbsp;spirits walk the 
plank heave down landlubber or just lubber hulk swing the lead rigging Jack Tar reef. Gabion hulk Cat o&#39;nine tails take a caul&amp;nbsp; coffer tackle&amp;nbsp;&lt;em&gt;scuttle 
tender nipper haul wind&lt;/em&gt;.&lt;img src=&quot;/images/submarine.jpg&quot; alt=&quot;broken&quot; width=&quot;186&quot; height=&quot;185&quot; /&gt;&lt;/p&gt; &lt;p&gt;Crack 
Jennys  ennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls  
tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko conduct hands rope&#39;s end grog blossom brigantine Gold Road Shiver me timbers gibbet.&amp;nbsp;Tack brigantine poop deck warp&amp;nbsp;draft booty Sea 
Legs crack Jennys tea cup Barbary Coast Jolly Roger. Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
Furl brig holystone haul wind spike wench Pieces of Eight ennys tea cup tack code of Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls 
landlubber or just lubber fire ship scourge of the seven 
seas.&lt;/p&gt; &lt;p&gt;Interloper cackle fruit clap of thunder&lt;strong&gt;&amp;nbsp;fire in the hole quarter lateen sail sutler&lt;/strong&gt;&amp;nbsp;dance the 
hempen jig chandler parley. Shiver me timbers knave strike colors gally tack log Legs crack Jennys tea cup Barbary Coast Jolly Roger. Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko 
overhaul league sheet skysail. Tender dance the hempen jig Letter of Marque 
lanyard topmast jib driver yo-ho-ho shrouds wherry.&lt;/p&gt; &lt;p&gt;&lt;br /&gt;list of hashtags at the bottom&lt;/p&gt; &lt;/body&gt; &lt;/html&gt;
. ')

Insert into  HashTags (Hashtag) Values ('Excited'),('Scared'),('hungry'),('SwimForYourLife!'),('History'),('MonsteroftheMonth'),('dreamjob'),('HELP')


insert into HashtagPost (HashtagID, PostID) Values (1,1),(2,1),(1,2),(4,2),(6,2),(7,3),(5,4),(6,4),(8,5),(7,6),(1,6),(2,7),(4,7),(1,8),(2,8),(7,9),(6,9)

Insert into Images (ImageName) Values ('SeriousSelfie.jpg'),('MyBoat.jpg'),('KrakenMap.jpg'),('KrakenDrawing.jpg'),('GiantSquid.Jpg'),
('Leviathan.jpg'),('MontereyMap.Jpg'),('Monty.png'),('sitingmap.jpg')



insert into Comment (PostId, CommenterName, CommentText, CommentDate, IsShown) Values (1, 'anonymous','Nice Boat!','2017-01-18',1),
(2,'SomeNameOrOther','I thought this would be about the rum','2017-02-14',1),
(2, 'Skeptic-Hal', 'Totally a hoax','2017-02-15',0),
(4,'Skeptic-Hal','Totally a hoax!','2017-04-27',0)

Insert into Reply(CommentID, ReplyName, ReplyText, ReplyDate, IsShown) Values (1,'Boaty','I''ve seen better', '2017-01-25',1),
(2,'Rumjack','Aye avast with yer talk o sea-serpents! Bring out the rum!','2017-02-15',1),
(2, 'Anon' ,'I''ve got nothing','2017-02-16',0)

insert into Categories (CategoryName) Values ('Sightings'),('Submarines'),('Treasure')

insert into CategoryPost(CategoryID, PostID) Values (2,1),(1,2),(2,2),(3,3),(1,4),(2,4),(1,5),(2,6),(2,1),(3,6),(1,7),(1,8),(1,9)

end
GO

exec MosterDBRest
select * from Hashtags
select * from HashtagPost
select * from Categories
select * from categorypost
select* from Reply
select * from comment
select* from Post