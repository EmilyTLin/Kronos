VAR playername = "Kronos"

// BLACK SCREEN:

???: We've been here before, {playername}. #align unknown
???: You know you can't win this, right? And, hey, maybe that's for the best - the "win" outcome is pretty twisted after all."

    * [What do you mean?]
    {playername}: What are you talking about? 
    ???: Tch, of course you don't understand. How could you?
    ->resolve

    * [We can still win.]
    {playername}: We can still win. 
    ???: What "we"? There is no "we", anymore. You're welcome for that, by the way. 
    ->resolve
    
    * [Fuck you.]
    {playername}: Fuck you. 
    ???: ... Y'know, that's fair. Given what you think you know.
    ???: But you'll see, {playername}. When you see the outcome, you'll understand that this really is for the best.
    ->resolve

    * [...]
    {playername}: ... 
    ???: You kinda look like you wanna punch me right now...
    ???: Or maybe you're just speechless? Maybe a bit of both? I was never great at reading you, {playername}.
    ->resolve
    
=== resolve ===

{playername}: I'll stop you. 

???: What're you gonna do, {playername}? You're running out of juice. What're we at now? Like, eight-seven?  

{playername}: ( Ninety... This'll probably be… ) #color blue

???: I'm betting... this'll be your last chance, huh?  #color black

{playername}: ( She's right... I'm running on fumes at this point... ) #color blue

{playername}: I'll stop you. #color black
{playername}: Even if that means I have to stop all of them, too.

{playername}: ( I hoped it wouldn't come to this... But you know what they say: Hope for the best, prepare for the worst. ) #color blue

You reach into your pocket. #color green

{playername}: ( This is my last chance... ) #color blue

// { Time travel sound }

// FADE TO WHITE

-> END