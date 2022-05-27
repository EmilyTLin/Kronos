VAR playername = "Kronos"

//IF THIRD+ TIME:

Colette: Did ya need something? #align right

*[ Where did this comic... ]
    {playername}: Where do you think this comic came from? #align left

    Colette: Honestly? No clue whatsoever. #align right
    Colette: I'm... it kind of confuses me, to be honest. This feels like something I would know about, haha.
    
    -> finish

    // { CLOSES PATH }

*[ Where can I get info? ]
    
    {playername}: Where can I get information about past events? #align left
    Colette: I'd check the archive room in the corner of the library. Let me know if you'd like any help looking! #align right
    
    -> finish
    
    // { CLOSES PATH }

*[ This looks like you. ]
    
    {playername}: That looks like you in the comic. #align left
    Colette: I... The resemblance is uncanny.  #align right
    Colette: ... 
    Colette: ... 
    Colette: Okay, fine! I wasn't good at keeping my secret identity even then. I guess it doesn't even matter now... 
    Colette: Yes, that's me. I think.
    -> identity
    
=== identity ===
    
*[ You think? ]

{playername}: You think? #align left
Colette: Yeah, it's weird. Because this comic... it's not really... accurate. Because I... I mean, I'm not a hero anymore. #align right
-> what_happened1

*[ You're a superhero. ]

{playername}: You're a superhero. #align left
Colette: Was. I was a superhero. And I loved it.  #align right
Colette: But I can't do that anymore.
-> what_happened1
    
=== what_happened1 ===

    *[ Why not? ]
    
    {playername}: Why not? #align left
    Colette: Weak legs, haha. #align right
    -> goodbye
    
    *[ I'm sorry. ]
    
    {playername}: I'm sorry. #align left
    Colette: It's... it's okay. It's in the past, y'know. I'm over it! Haha... #align right
    -> goodbye
    
    *[ But this comic says... ]
    
    {playername}: This comic shows you as a hero, though. #align left
    Colette: Yeah, I don't know what's up with that. It's... wrong. The... the fire. It didn't go down like that. #align right
    -> regret
    
=== regret ===

    *[ What do you mean? ]
    
    {playername}: What do you mean? #align left
    Colette: It's just... wrong, y'know?  #align right
    Colette: I mean, clearly I'm not a hero anymore, and I don't know any of these other heroes in these comics. 
    Colette: It's just... really weird. It feels like I'm reading the "good timeline," haha.
    -> goodbye
    
    *[ I see. ]
    
    {playername}: I see. #align left
    Colette: Yeah... #align right
    -> goodbye
    
=== goodbye ===
    
    Colette: Anyways, I have to get back to work. Let me know if there's anything else I can do for you. #align right
    -> finish

=== finish ===

-> END