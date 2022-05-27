VAR playername = "Kronos"

/*
IF NEWS CLIPPING IN INVENTORY AND LEARNED COLETTE WAS THE STREAK (THROUGH CONVERSATION WITH HER) (ALSO SHOULD ONLY ACTIVATE IF TALKED TO COLETTE AT LEAST TWICE. -Steve): 
*/

*[ This newspaper... ]
Colette: Oh. Yeah. That. Ancient history. Kind of? #align right
-> newspaper

=== newspaper ===

*[ It doesn't match... ]
{playername}: It doesn't match the comic. #align left

Colette: Yeah, weird, right!? I noticed that too! #align right
Colette: The fire's wrong, and I don't know any of these other people. Aside from Bonnie and Clyde - the fire dude and strong woman couple. 
Colette: I see them on the news sometimes still, never fought them myself though. 
Colette: I was just fast, y'know, I can't take down these big-time villains.

{playername}: What really happened? #align left
    -> what_happened2

// { ROUTE TO [ What really happened? ] RESPONSE }

*[ What really happened? ]
{playername}: What really happened? #align left
    -> what_happened2

// { ROUTE TO [ No, you’re not. ] AND [ Yeah, a bit. ] AND [ You’re not anymore. ] }

*[ You were injured? ]
{playername}: You were injured? #align left

Colette: Ah, yeah. I mean... that's why I'm not a hero anymore. #align right
Colette: I ran in, the door to the girl's room was jammed, and before I could break through... crack. 
Colette: The floorboards beneath me broke. And I fell. 
Colette: Broke both my legs pretty bad. Couldn't run anymore after that. Couldn't save that kid either...
Colette: God, I'm a pretty useless hero, huh?
    -> useless_hero
    
*[ Who died? ]
{playername}: Who died? #align left

    Colette: ... #align right
    Colette: Her name was Amy Liu. She was 8 years old.
    
    Colette: ...
    Colette: I have to get back to work, sorry.
    -> finish
    
=== what_happened2 ===
Colette: I ran in, the door to the girl's room was jammed, and before I could break through... crack.  #align right
Colette: The floorboards beneath me broke. And I fell. 
Colette: Broke both my legs pretty bad. Couldn't run anymore after that. Couldn't save that kid either... 
Colette: God, I'm a pretty useless hero, huh?
    -> useless_hero

=== useless_hero ===

*[ No, you're not. ]
{playername}: No, you're not. #align left

Colette: Aw, that's sweet. It's too bad none of the tabloids agree with you.  #align right
Colette: After the fire, they kept comparing me to the "gods of old" and stuff, and how I was a massive failure. 
Colette: Didn't feel too great, not gonna lie. But it's okay, it's all in the past.
Colette: Anyways, I have some books to scan in, but I'll talk to you later!
    // { CLOSES PATH }
    -> finish

*[ Yeah, a bit. ]
{playername}: Yeah, a bit. #align left

Colette: Haha, yeah, you sound like all the tabloids.  #align right
Colette: After the fire, they kept comparing me to the "gods of old" and stuff, and how I was a massive failure. 
Colette: Didn't feel too great, not gonna lie. But it's okay, it's all in the past.
Colette: Anyways, I have some books to scan in, but I'll talk to you later!
    // { CLOSES PATH }
    -> finish

*[ Not anymore. ]
{playername}: You're not anymore.  #align left

Colette: I mean, you're right, but you could be at least a little sympathetic. #align right
Colette: I'm going to get back to work. Sorry.
    -> finish

=== finish ===

-> END
