use SeaMonster
go

delete from Images
delete from PostText
delete from CategoryPost
delete from Categories
delete from post 
DBCC CHECKIDENT (Post,reseed, 0)
DBCC CHECKIDENT (Images,reseed, 0)
DBCC CHECKIDENT (Categories,reseed, 0)
DBCC CHECKIDENT (PostText,reseed, 0)


Insert into Post (PostTitle, ispublished, DateCreated) Values ('Hello Fellow Monster Hunters',1, '2017-01-15'),('Cracking the Kraken',1,'2017-02-12'),
				('Leviathan Wakes!',1,'2017-03-01'), ('The Monster of Monterey',1,'2017-04-26'),('A History of Hoaxes',0,'2017-05-03')
GO

Insert into PostText (PostId, PostText) values (1,'Me bucko cog ho hang the jib black spot weigh anchor swing the lead spirits to go on account. Aft draft reef sails quarter spirits Sink me keelhaul jolly boat cutlass bilge. Jolly Roger measured fer yer chains six pounders salmagundi hulk weigh anchor lanyard pinnace crimp dead men tell no tales.
Piracy ahoy chandler yard overhaul lugger clap of thunder mutiny Plate Fleet parley. Deadlights loot boom shrouds matey spirits hearties Admiral of the Black black spot wench. Spanker bilged on her anchor topmast Chain Shot Barbary Coast American Main driver chase red ensign reef sails.
Jack holystone Nelsons folly shrouds lee starboard keelhaul capstan sheet clipper. Mutiny flogging cog long clothes Jack Tar shrouds salmagundi hogshead case shot draught. Cat o''nine tails fore port aft tackle Letter of Marque Brethren of the Coast bounty yawl hands. '),
(2,'Boatswain flogging furl Barbary Coast ballast capstan barkadeer skysail rigging log. To go on account ye sloop clipper tack me grog black spot piracy 
heave down. Hands weigh anchor bounty dead men tell no tales Privateer matey bilge trysail yo-ho-ho jury mast.
Log haul wind me Pieces of Eight spike reef sails pirate Arr line grapple. Snow yardarm gangplank boatswain lee reef tender bilge water 
quarterdeck pink. To go on account Cat o''nine tails sheet gun furl stern ho keelhaul fire in the hole crimp.
Quarterdeck gangplank scuppers bilge driver warp clap of thunder sheet transom loaded to the gunwalls. Chantey 
Blimey Pieces of Eight provost chandler man-of-war jury mast fire ship Chain Shot Jack Ketch. 
Furl Plate Fleet lass gaff grog bilge mutiny pinnace marooned hearties. '),
(3,'Carouser bring a spring upon her cable trysail shrouds hands gunwalls cog Sink me bucko case shot. Dead men tell no tales 
hang the jib ye Jolly Roger bilge water jolly boat sheet jury mast pink landlubber or just lubber.
Lanyard nipper grog aye poop deck reef bilge rat square-rigged spyglass measured fer yer chains.
Coxswain jib lookout bucko strike colors Arr rutters capstan topgallant barque. Lass stern ballast Nelsons 
folly Plate Fleet Admiral of the Black hardtack chase capstan fathom. Killick scuttle grog avast code of conduct 
Spanish Main jack barque bilged on her anchor schooner. '),
(4,'Port gangplank swab code of conduct wench Plate Fleet Jolly Roger fore rum swing the lead. Ho doubloon warp gabion salmagundi ahoy lanyard prow gaff flogging. Ahoy run a rig 
barque topgallant spyglass line swab sheet ballast dance the hempen jig.
Gaff long boat chandler jolly boat execution dock matey topsail fire ship Arr 
nipper. Crack Jennys tea cup tender Plate Fleet shrouds Davy Jones'' 
Locker warp loot brig measured fer yer chains stern. Hail-shot spike bucko hogshead hempen 
halter lookout driver matey smartly chase guns.
Crow''s nest topsail scuttle Letter of Marque fluke warp poop deck yardarm take a caulk broadside. 
Jack Tar killick grapple gangway Shiver me timbers execution dock heave to yardarm scourge of the seven seas 
hornswaggle. Fire in the hole heave down mizzen sloop black spot lee hang the jib gabion hulk code of conduct. '),
(5,'Help! I am being held on a boat and forced to write this blog.')
GO

Insert into  Categories (CategoryTag) Values ('Excited'),('Scared'),('hungry'),('SwimForYourLife!'),('History'),('MonsteroftheMonth'),('dreamjob'),('HELP')


insert into CategoryPost (CategoryID, PostID) Values (1,1),(2,1),(4,2),(6,2),(7,3),(5,4),(6,4),(8,5)

Insert into Images (ImageName, PostId) Values ('SeriousSelfie.jpg',1),('MyBoat.jpg',1),('KrakenMap.png',2),('KrakenDrawing.png',2),('GiantSquid.Jpg',2),
('Leviathan.jpg',3),('MontereyMap.Jpg',4),('Monty.png',4),('sitingmap.png',4)



insert into Comment (PostId, CommenterName, CommentText, CommentDate, IsShown) Values (1, 'anonymous','Nice Boat!','2017-01-18',1),
(2,'SomeNameOrOther','I thought this would be about the rum','2017-02-14',1),(4,'Skeptic-Hal','Totally a hoax!','2017-04-27',0)

Insert into Reply(CommentID, ReplyName, ReplyText, ReplyDate, IsShown) Values (1,'Boaty','I''ve seen better', '2017-01-25',1),
(2,'Rumjack','Aye avast with yer talk o sea-serpents! Bring out the rum!','2017-02-15',1)