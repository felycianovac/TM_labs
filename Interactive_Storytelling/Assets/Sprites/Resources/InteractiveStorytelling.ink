VAR eng = 0
VAR com = 0
VAR dip = 0
VAR knows_binefactor = false
VAR knows_pirates = false
VAR knows_artifact_legend=false
VAR sceneSetting = "default"
VAR has_advanced_weapon = false
VAR music="intro"
->Introduction
==Introduction==
~sceneSetting="introduction"
As the ship hums quietly against the backdrop of the cosmos, I take a moment to reflect. "I'm Alex," I think to myself, "a spacefarer, a seeker of the lost and the hidden. I left the familiar behind a long time ago, chasing whispers on the edge of the unknown. Some call it a lonely path, but out here, among the stars, I'm more at home than I ever was on solid ground." <br>The Oddyssey, my trusty vessel, has been more than just a ship to me. "Just me and you, Zara" I say, glancing at the AI's interface that lights up in response.<br>It's funny how the vastness of space can make you introspective. Each planet, each asteroid field, every nebula I've encountered, has been a teacher of sorts. I've learned about resilience in the face of the eternal night, about wonder, and about the kind of peace you can only find when you're light-years away from everything else.
*[Continue]
->ArtefactIntroduction 
    -> END
==ArtefactIntroduction==
~music="artifactintro"
~sceneSetting="artifactintro"
Zara flickers to life, her voice calm yet imbued with an edge of excitement. "Alex, there's an unknown signal emanating from that desolate planet. It's... unusual." <br>I can't help but crack a half-smile. "Unusual is my middle name, Zara. You know I can't resist a good mystery." My hand hovers over the console, ready to chart a new course. <br>The Odyssey's landing sends a shiver through the silent planet. Suited up, the seal of my helmet clicks — the only sound in this vast solitude. I'm out on the surface, alone with the universe's mysteries. <br>Boots thudding softly, I approach an anomaly — a relic, ageless and serene, its glyphs whispering secrets. "Keep an eye on this, Zara," I say as I trace the enigmatic symbols. The artifact thrums with life, a quiet power that's now mine to claim. <br>"Energy levels rising," Zara's voice cuts in, tinged with concern. But I'm past the point of hesitation. Artifact in hand, I head for the ship. Ahead lies the unknown, beckoning with unasked questions and unseen answers.
*[Continue]
->VarekIntroduction 

->END
==VarekIntroduction==
~sceneSetting="varekintro"
~music="varekintro"
As I secure the artifact in the Odyssey's hold, a new signal pierces the silence, slicing through the static like a knife. I hesitate, my hand hovering over the console. "Incoming transmission," the ship's system announces, its voice neutral, betraying none of the urgency I feel pulsing just beneath my ribcage. <br>I press the button and his image materializes before me. Varek. Even his name carries a weight, a sense of inevitable gravity. "I'll be brief," he begins, his tone disarmingly cordial. "You have something I need. <br>The artifact. Of course. It's always about the artifacts out here, where history and greed collide. <br>"I propose an exchange," Varek continues, smiling like a wolf baring teeth. "You give me the artifact, and I assure you, it will be for the best. No need for unpleasantness between us." <br>The screen flickers with the soft glow of distant stars, casting Varek's face in sharp relief. I can almost feel the tension, a taut line drawn between us, spanning the void. 
He's offering peace, but the air between the words is charged, heavy with unspoken threats. I weigh my options, the artifact a sudden anchor in my palm. Trust is the currency of the foolhardy out here, and I am no fool. Yet, refusing Varek feels like stepping into a snare.
*[Give artefact to Varek]
->GiveArtefact
*[Refuse Varek's proposal]->ZaraStealing
->END

==GiveArtefact==
~music="giveartefact"
~sceneSetting="giveArtefact"
"I've considered your offer, Varek," I begin, my voice steady despite the turmoil churning within. "Collaboration could be beneficial for both of us. The artifact—" <br>The words catch in my throat, an invisible force silencing the acquiescence on my lips. It's as if the very essence of the cosmos is urging me to pause, to reconsider the path I'm about to tread. The notion of handing over such an enigmatic relic, one that might hold the keys to untold secrets of the universe, to Varek... it feels inherently wrong. <br>Are you sure about that?


*[Yes]->WorstEnding
*[No]->VarekIntroduction
->END

==WorstEnding==
~sceneSetting="worstEnding"
~music="worstending"
Resolute yet uneasy, I agree to Varek's terms. "I'll meet you," I say, trying to quell the doubt gnawing at my heart. <br>Varek's reply is swift, his smile chilling. "Bring the artifact to the station. History awaits us, Alex. <br>As the Odyssey nears the station, hidden among asteroids, a sense of dread tightens around me. But there's no turning back now. <br>The exchange is brief and tense. The artifact, now in Varek's grasp, seems almost to protest its new master. As I retreat, Varek's betrayal unfolds—a sudden blast, and the Odyssey is engulfed in flames. <br>Epilogue: <br>With the artifact's power, Varek's dominion over the galaxy is absolute, ushering in an era of tyranny. My name is lost, a mere echo in the vast expanse of space.
-> END
==ZaraStealing==
~sceneSetting="zaraStealing"
~music="zarastealing"

In the tension-laden silence following my refusal to hand over the artifact, Varek's visage hardens on the display. "You will regret this unwise decision!" he declares, and the transmission abruptly ends, leaving a cold void in its wake. <br>The gravity of my choice settles in as I grip the console tighter. Varek's threat echoes in the stillness, a stark reminder of the dangers that lie in crossing paths with him. <br>Suddenly, the ship's systems alert me to a critical anomaly. "System breach detected," the Odyssey warns, its calm tone belying the severity of the situation. My heart sinks as I realize the breach's source—Zara, my AI companion, the guiding light of my solitary journey through the cosmos, is being extracted from the ship's network. <br>I scramble to counteract the intrusion, but it's futile. Zara's presence fades from the screens, her voice, once a constant in the vast silence of space, silenced.
Varek has taken her, not just as a companion but as a bargaining chip, ensuring I have no choice but to follow him into the dark. <br>The loss is palpable, a void where Zara's light once filled the Odyssey. It's more than the absence of an AI; it's the loss of a friend, a voice in the endless night. As I set a course, driven by a mix of grief and determination, I know the journey ahead is not just for the artifact anymore. It's for Zara, whose absence has left a galaxy-sized hole in the fabric of my universe. <br>What shall I do next without her?
*[Secure the artifact for later and try to track down Varek]->TrackVarek

*[Investigate Artefact]-> InvestigateArtefact
->END

==TrackVarek==
~sceneSetting="trackVarek"
~music="trackVarek"
~ eng+=1
~ dip+=1
~knows_binefactor=true
In the silent expanse of space, with the weight of my decision pressing down, I secure the artifact within the Odyssey. It's a beacon of untapped potential, but Zara's safety overshadows all else. I set out to track down Varek, to bring her back from whatever digital prison he's confined her to. But Varek is a ghost in the cosmos, always a step ahead, leaving me grasping at shadows. <br>After while, an unexpected opportunity presents itself. A message breaches the Odyssey's encrypted channels, its origin a mystery. The sender, a figure known only as Orion, claims an intimate understanding of the artifact and Varek's machinations. Orion's voice, filtered through the static, carries a tone of calculated confidence. "Varek is a formidable foe, one I too have crossed paths with," Orion reveals, hinting at a history marred by conflict. <br>Orion offers not just information but a partnership.
"The artifact is a key, Alex, one that Varek must not possess. Together, we can stay his hand." But it's the promise of aiding in Zara's retrieval that catches my breath. Could this be the break I've been searching for? <br>Yet, as enticing as Orion's offer is, the shadows that cloak his intentions are deep. Trust is a commodity in short supply, especially when dealing with unseen allies. Could aligning with Orion tilt the scales in my favor, or is it merely trading one devil for another? <br>Zara's absence is a void no starlight can fill, and if Orion can help me navigate the darkness to find her, perhaps it's a risk worth taking. But in the game of cosmic chess, every move is fraught with consequence, and I must tread carefully lest I become a pawn in Orion's unseen agenda.
*[Accept the Orion's Help]->AcceptOffer
*[Decline Orion's Help]->DeclineOffer
->END

==InvestigateArtefact==
~eng+=1
~sceneSetting="investigateArtefact"
~music="investigateArtefact"
Reeling from Zara's loss, the silence of the Odyssey feels heavier, the void she left echoing in every corner of the ship. Varek's words, a grim promise of regret, hang in the void she once filled. Yet, amidst the turmoil, the artifact beckons, its enigmatic glow a constant amidst the chaos. <br>With a resolve sharpened by grief, I turn my focus to the artifact. If knowledge is power, then perhaps within its ancient design lies the key to overcoming Varek, to bringing Zara back. The device, pulsing with a cryptic energy, seems almost alive, its secrets locked beneath layers of forgotten lore. <br>I initiate a deep scan of the artifact, the Odyssey's advanced sensors probing its composition, seeking a breach in its mysteries. The data streams in, a cascade of symbols and energy patterns that defy known physics. I cross-reference the findings with the Odyssey's vast database, piecing together fragments of ancient civilizations that once harnessed the stars themselves.
<br>The breakthrough comes in the form of a hidden mechanism within the artifact, a sophisticated interface that responds to my touch. It's a puzzle, each glyph a piece of a larger cosmic tapestry. With careful manipulation, informed by the snatches of lore uncovered in the data, I activate the mechanism. It's a map of sorts, revealing pathways through the cosmos that bend distance and reality, paths unknown to even the likes of Varek. In the wake of this revelation, Zara's absence is a stark reminder of the stakes at play. The knowledge gained is a beacon in the dark, a promise of hope amidst despair. <br>How shall I use it?
*[Develop a New Weapon]->DevelopTool
*[Integrate Ship]->IntegrateShip
->END

==AcceptOffer==
~music="acceptOffer"
~sceneSetting="acceptOffer"
~dip+=3
~eng+=2
~knows_binefactor=true
Accepting Orion's offer, I delve into the unfolding alliance. His image flickers with distant starlight as he unveils our strategy against Varek. Decrypting his network is our first step, armed with codes from past skirmishes to gain an edge. Orion guides us to hidden caches across the galaxy, stockpiles unknown to Varek, shielding the Odyssey from his prying eyes with a cloaking device. <br>The artifact, a confluence of ancient energies, holds the key to awakening dormant capabilities, offering strategic shortcuts through cosmic pathways. Under Orion's guidance, I tweak the artifact, unveiling a secret map of the galaxy. Detailed intelligence on Varek's vulnerabilities becomes apparent, setting the stage for exploiting his overconfidence. <br>With each revelation, the artifact sheds its mystery, revealing profound cosmic secrets and paving the way for our resistance against Varek's tyranny.
*[Continue]->Pirates
->END

==DeclineOffer==
~sceneSetting="declineOffer"
~music="declineOffer"
~eng+=2
~com+=1
In the Odyssey's cockpit, I weigh Orion's offer against the silence of space. "I must decline, Orion. I tread this path alone," I assert, feeling the weight of my solitude but also the strength it grants me. Orion's image fades, leaving me with my thoughts and the hum of the ship. <br>The decision to reject Orion's alliance leaves me with a sense of stark independence. It's time to focus on the Odyssey and the mysterious artifact in my possession. I dive into the ship's systems, enhancing our defenses and propulsion, ensuring we're swift and elusive, a ghost among the stars. <br>I turn my attention to the artifact, its enigmatic surface pulsing with untapped potential. With careful adjustments, I aim to harness its energy, to perhaps give the Odyssey an edge we've never had before. Each tweak feels like a conversation with the ancient relic, a negotiation of power and restraint. 
The work is exhaustive but fulfilling. The Odyssey, now bristling with upgraded defenses and a whisper of ancient power, feels ready to face whatever lies ahead. In this moment of quiet determination, I'm reminded that the journey is mine to shape, with the artifact as a silent guide through the uncharted vastness of space.


*[Continue]->Pirates

->END

==DevelopTool==
~has_advanced_weapon=true
~eng+=3
~com+=2
~music="developTool"
~sceneSetting="developTool"
With the artifact's secrets laid bare before me, the allure of power becomes irresistible. I resolve to harness its energies for a singular purpose—to forge a weapon unlike any other, capable of turning the tide against Varek and his ilk. <br>Drawing upon the artifact's cosmic energies, I set to work, designing a prototype that channels its raw power into a focused beam of destruction. The Odyssey's fabrication systems hum to life, shaping the weapon with precision as I fine-tune its capabilities. <br>As the weapon takes shape, I can feel the artifact's energy pulsing within it, a promise of untold devastation. With each adjustment, the prototype grows more potent, a testament to the ancient wisdom woven into its design. 
Yet, even as I revel in the weapon's potential, a nagging doubt tugs at the corners of my mind. Power unchecked is a dangerous ally, and I must tread carefully lest I become that which I seek to overcome. But for now, the lure of victory outweighs the risks, and I press on, driven by the hope of turning the tide against Varek's tyranny.
*[Continue]->Pirates
->END

==IntegrateShip
~music="integrateShip"
~sceneSetting="integrateShip"
~eng+=5
The artifact's energies hold the key to unlocking the Odyssey's full potential, to transforming her from a mere vessel into something greater. <br>With careful precision, I begin the integration process, linking the artifact's cosmic energies with the ship's systems. The Odyssey becomes a conduit, a vessel for the artifact's power, each component working in harmony to enhance her capabilities. <br>As the integration progresses, I can feel the ship come alive beneath my hands, her systems humming with newfound vitality. The artifact's energy infuses every corner of the Odyssey, from her propulsion systems to her defensive matrix, imbuing her with a strength and resilience unmatched in the cosmos. <br>With the integration complete, I stand back, surveying the transformed Odyssey with a sense of awe. She is more than a ship now; she is a beacon of hope in the darkness, a testament to the power of unity and cooperation.
*[Continue]->Pirates

->END
==Pirates==
~sceneSetting="pirates"
~music="pirates"
After a while, while testing my Oddysey, cruising through the vast expanse of space, a blip appears on the radar, growing steadily larger with each passing moment. Before I can react, the ship shudders as a hail of energy blasts erupts from the darkness, painting the void in streaks of crimson. <br>Alarms blare as I rush to the cockpit, the air thick with tension as I assess the situation. Before me looms a ragtag fleet of ships, their hulls scarred with the marks of countless battles. At their helm, a figure clad in tattered robes, the unmistakable silhouette of a space pirate captain. <br>With a grim resolve, I weigh my options, each one fraught with peril. Fighting them head-on would be a test of skill and courage, with victory far from assured. Tricking them into a hasty retreat could buy us time, but at what cost to our integrity? Negotiating peace may seem noble, but can I trust these pirates to honor their word, or am I merely inviting betrayal?
As the pirates draw closer, their intentions clear, I know that the choice I make in this moment will shape the course of our journey. Will I stand and fight, weave a web of deception, or extend the olive branch of diplomacy?
{knows_binefactor:
+[Trick Pirates and Escape]->TrickPirates
}
*[Fight Off Pirates]->FightPirates
*[Negotiate Peace and create allies]->NegotiatePeace
->END

==TrickPirates==
~music="trickPirates"
~sceneSetting="trickPirates"
~eng+=2
~com+=1
As the pirate fleet draws nearer, I realize that a direct confrontation would be folly. <br>With a quick glance at the console, I initiate a series of evasive maneuvers, weaving through the chaos of battle with precision and grace. The pirates, caught off guard by our sudden agility, struggle to keep pace as we slip through their grasp like a phantom in the night. <br>As we navigate the treacherous dance of combat, I seize the opportunity to enact my plan. With a flick of a switch, I activate the Odyssey's stealth systems, cloaking us from the pirates' sensors and plunging us into the shadows of the void. <br>With our pursuers momentarily blinded to our presence, I plot a course for escape, charting a path through the asteroid field ahead. As we slip through the rocky maze, the pirates' cries of frustration fade into the distance. 
The encounter with the space pirates has highlighted the vulnerabilities of the Odyssey, and I must choose how to address them. Will I focus on developing specific countermeasures to combat future tactics? Or shall I prioritize upgrading our ship's stealth systems? This is important before I confront Varek.

*[Develop Countermeasures]->DevelopCounter
*[Improve Ship's stealth capabilities]->ImproveShip
->END
==FightPirates==
~music="fightPirates"
~sceneSetting="fightPirates"
~com+=3
With a grim determination, I prepare to engage the enemy head-on, knowing that the outcome of this battle could shape the course of our journey through the stars. <br>The pirates open fire, their energy blasts streaking through the void with deadly accuracy. I return fire with equal ferocity, the hum of the Odyssey's weapons systems echoing through the cockpit as I unleash a barrage of counterattacks. <br>Amidst the chaos of battle, I spot an opportunity to salvage valuable pirate tech and data. With a calculated maneuver, I lead the pirates into a carefully orchestrated trap, disabling their ships one by one and boarding them to seize their technology and gather vital intelligence. <br>
{has_advanced_weapon: With our enhanced weaponry and combat skills, we quickly gain the upper hand, overwhelming the pirates with our superior firepower. Their ships crumble beneath the onslaught, their defenses no match for our advanced weapons systems. In the aftermath of the battle, we salvage the wreckage of the pirate fleet, scavenging valuable technology and data that will aid us in our journey through the stars.}
{not has_advanced_weapon: Though the battle is fierce, we find ourselves locked in a deadly stalemate with the pirates. Their numbers are overwhelming, and our weapons systems struggle to keep pace with their relentless assault. Despite our best efforts, we are unable to gain the upper hand, and the battle reaches a stalemate as both sides lick their wounds and regroup for the next confrontation. However, amidst the chaos of battle, we manage to salvage some valuable pirate tech and data, providing us with a glimmer of hope amidst the darkness of space.}


*[Improve Ship's stealth capabilities]->ImproveShip
*[Combat Upgrade from Salvaged Tech]->CombatUpgrade
->END
==NegotiatePeace==
~music="negotiatePeace"
~sceneSetting="negotiatePeace"
~dip+=3
~knows_pirates=true
With a deep breath, I consider the possibility of negotiation, recognizing that the pirates could become valuable allies in the turbulent depths of space. <br>With a calm demeanor, I reach out to the pirate captain, extending an offer of peace and cooperation. Despite the tension crackling in the air, I speak with sincerity, appealing to our shared humanity and the potential for mutual benefit. <br>The pirate captain's response is guarded, but not hostile. As we engage in a delicate dance of diplomacy, I find common ground and sow the seeds of a fragile alliance. It's a risky gambit, but if successful, it could tip the scales in our favor in the battles to come. <br>As the negotiations progress, I can't help but feel a glimmer of hope amidst the uncertainty of the void. If we can turn these pirates into allies, our journey through the stars may yet hold the promise of brighter days ahead.

*[Combat Upgrade from Salvaged tech]->CombatUpgrade
*[Explore Hidden Base]->RecruitPirate
->END

==CombatUpgrade==
~sceneSetting="combatUpgrade"
~music="combatUpgrade"
~com+=4
With the wreckage of the defeated pirate fleet scattered around us, I turn my attention to salvaging whatever useful technology and data we can find amidst the debris. Among the scattered remnants, I identify components that could potentially enhance our combat capabilities. 
{has_advanced_weapon:As we integrate the salvaged tech into our existing systems, I can't help but feel a surge of excitement at the possibilities. With our enhanced weaponry and combat skills, we stand poised to face any future threats with confidence, our ship now a formidable force to be reckoned with in the unforgiving expanse of space.}
{not has_advanced_weapon:Despite our best efforts, the salvaged tech proves to be more challenging to integrate than anticipated. While we manage to make some improvements to our combat capabilities, it's clear that we still have a long way to go before we can match the prowess of our adversaries. Nonetheless, even the modest upgrades we've made give us a glimmer of hope as we continue our journey against Varek.}


*[Continue]->PlanVarek
->END


==RecruitPirate==
~music="recruitPirate"
~sceneSetting="recruitPirate"
~dip+=4
As the negotiations progress, I find myself considering a bold proposition: recruiting pirate crew members to join our cause. <br>With the promise of amnesty and a fresh start, I extend the offer to the pirate crew, emphasizing the potential benefits of cooperation and the opportunity to leave their lawless past behind. The response is mixed, with some expressing skepticism while others show genuine interest in the prospect of a new beginning. <br>Amidst the cautious optimism, I identify individuals with valuable skills and experience, reaching out to them individually to discuss their potential role on the Odyssey. Together, we discuss strategies for integrating them into our crew, addressing concerns about trust and compatibility.
Despite the challenges, I can't help but feel a sense of hope as we forge new alliances amidst the uncertainty of space. If successful, these former pirates could prove to be valuable assets, bringing their unique expertise and perspectives to our journey through the stars.
*[Continue]->PlanVarek

->END
==DevelopCounter==
~sceneSetting="developCounter"
~music="developCounter"
~eng+=2
~com+=5
With the threat of future encounters with space pirates looming large, I dedicate our resources to developing specific countermeasures against their tactics, with Orion's help as well. We invest in advanced electronic decoys to confuse their targeting systems, along with improved shields to withstand their relentless assaults. It's a strategic decision that will require careful planning and execution, but one that could prove vital in the battles to come, especially against Varek.
*[Continue]->PlanVarek
->END
==ImproveShip==
~eng+=4
~sceneSetting="developCounter"
~music="developCounter"
Recognizing the importance of avoiding future confrontations with space pirates, I choose to prioritize upgrading our ship's stealth systems, by investing in enhancing our ability to evade detection even in the most hostile environments. Additionally, I'll optimize our sensor arrays to detect potential threats from a greater distance, giving me ample time to adjust course and avoid danger. It's a decision that requires foresight and planning, but one that could ultimately tip the scales in our favor and against Varek.
*[Continue]->PlanVarek
->END

==PlanVarek==
~sceneSetting="planVarek"
~music="planVarek"
As the debris of the defeated pirate fleet fades into the void behind us, I turn my focus towards our next encounter with Varek. With the threat of his looming presence ever-present in my mind, I gather my crew in the heart of the Odyssey's command center to strategize our approach. <br>As we weigh our options and chart our course forward, one thing remains clear: our encounter with Varek will be a defining moment in our journey, one that will test not only our skills but our resolve as well. Whatever path we choose, one thing is certain – the fate of the galaxy hangs in the balance, and it's up to us to shape its destiny. <br>The next chapter of our journey is about to unfold, and it will be shaped by the decisions you've made thus far. Your choices in the face of adversity, your alliances forged, and your skills honed will all play a pivotal role.
+ {eng>=7} [Strategic Sabotage]->StrategicSabotage
+{com>=4} [Direct Assult High]->DirectAssult

+{dip>=5} [Collaborate with Galactic Authorities]->CollabGalactic 
+{knows_binefactor} [Collaborate with Benefactor]->CollabBenef

+{knows_pirates} [Collaborate with Pirates]->CollabPirates
+{knows_binefactor and knows_pirates}[Collaborate with Benefactor and Pirates]->CollabBoth
->END
==StrategicSabotage==
~music="strategicSabotage"
~sceneSetting="strategicSabotage"
In the solitary confines of his personal quarters aboard the Odyssey, Alex immersed himself in the task at hand. With the galaxy's fate hanging in the balance, he knew that every decision he made would reverberate through the cosmos.<br>Surrounded by the soft hum of machinery, the glow of monitors and the Artefact sealed in the depth of the Odyssey, Alex's focus was unyielding.<br>Drawing upon his extensive training and experience, Alex formulated a plan to infiltrate Varek's fortress undetected. With a keen understanding of stealth tactics, he enhanced the Odyssey's cloaking systems, ensuring that they would slip through enemy sensors unnoticed.

But stealth alone would not suffice. With determination driving him forward, he set to work with the Artefact and use its power to translate his ship through the barriers. With each passing moment, the tension onboard the Odyssey mounted. Due to high Engineering skills, Alex made a Teleporter that uses Artefact and translates the ship in a specified location. Alex had no time to fully understand how reliable his new technology was, because it involves some unknown power from the artefact, but he was conviced that this was a step that can not be avoided.
*[Continue]->Fight1vs1
->END
==DirectAssult==
~music="directAssult"
~sceneSetting="directAssult"
Alone in the vast expanse of space, Captain Alex's resolve hardened like tempered steel as he stared down the looming silhouette of Varek's flagship. With a flicker of determination in his eyes, he knew that this confrontation would define the course of their conflict. <br>With no one to rely on, except himself, Alex's mind raced with strategies born from years of combat experience and a burning desire to confront Varek head-on. Drawing upon his arsenal of advanced weaponry and tactical expertise, he meticulously plotted his approach, every movement calculated with deadly precision.
*[Continue]->BecomeAnti
->END
==CollabGalactic==
~music="collabGalactic"
~sceneSetting="collabGalactic"
As the darkness of Varek's influence loomed over the galaxy, Captain Alex knew that brute force alone would not be enough to defeat him. With a shrewd mind and a gift for diplomacy, he set out to turn the governments of the galaxy against their common enemy. <br>Through tireless negotiations and skillful manipulation, Alex brokered alliances with key factions, leveraging their resources and manpower to bolster his own forces. With each new ally added to his cause, the tide of the conflict began to shift in his favor.
*[Continue]->LoseArtifact

->END
==CollabBenef==
~music="collabBenef"

~sceneSetting="collabBenef"
In a desperate bid for support, Alex turned to his Orion friend, a stoic warrior with a reputation for unyielding resilience and a hate for Varek. With a heavy heart and additional troops, the Orion pledged their allegiance to Alex's cause, their determination unwavering in the face of overwhelming odds. Together, they marshaled their forces and launched a daring assault on Varek's stronghold, their advanced technology and strategic prowess serving as their greatest assets. <br>But despite their best efforts, the Orion and their fellow warriors found themselves outmatched by Varek's superior numbers and formidable defenses. Wave after wave of enemy reinforcements descended upon them, their ranks thinning with each passing moment. Despite their valiant efforts, they could not withstand the relentless onslaught, and soon they found themselves forced be defeated. Alex was left alone to face Varek.
*[Continue]->ArtefactvsZara

->END
==CollabPirates==
~music="collabPirates"
~sceneSetting="collabPirates"
In a desperate bid for support, Alex turned to his pirate friends, a motley crew of swashbucklers and scoundrels with a reputation for daring exploits. Eager to prove themselves in battle, the pirates answered Alex's call with gusto, their ships descending upon Varek's base like a tempest unleashed. <br>But despite their bravado and reckless abandon, the pirates soon found themselves overwhelmed by Varek's superior forces and cunning tactics. Boarding parties were repelled with ruthless efficiency, their ships battered and broken beneath the relentless barrage of enemy fire. With each passing moment, their chances of victory grew increasingly slim, until finally they became 0. Alex was left alone to face Varek.
*[Continue]->ArtefactvsZara

->END

==CollabBoth==
~music="collabBoth"
~sceneSetting="collabBoth"
In a bold move, Alex reached out to his Orion and pirate allies, forging an alliance born of necessity in the face of Varek's looming threat. With their combined strength and cunning, they formed a formidable force, united in their determination to bring down the tyrant once and for all. <br>As they rallied their forces and set their sights on Varek's base, Alex knew that victory would not come easily. But with the support of his newfound allies, he was determined to see justice served and Zara freed from captivity. <br>In a coordinated assault, Alex led the charge alongside his Orion and pirate allies, their combined might overwhelming Varek's defenses and sweeping through his forces with ruthless efficiency. Despite Varek's best efforts, he was outnumbered and outmatched, his resistance crumbling beneath the weight of their assault.

With the support of his allies at his back, Alex fought with Varek, his every movement a testament to the strength of their alliance. Together, they pressed their opponent - Varek driving him with relentless determination. <br>It was a decisive strike from Captain Alex, bolstered by the unwavering support of his allies, that brought Varek to his knees. With a final, defiant roar, Varek fell, his reign of terror coming to a sudden and decisive end. <br>Alex was left alone to take care of Zara, while his allies went back to their ships and wait for his return.*[Continue]->GoodEnd
->END
==GoodEnd==
~sceneSetting="goodEnd"
~music="goodEnd"
With his allies by his side, Captain Alex forged a powerful coalition, united by a common goal: to wield the power of the Artefact for the greater good. The pirates, enticed by the promise of riches from Varek's stash of ill-gotten gains, lent their considerable skills and resources to the cause. Meanwhile, Orion, recognizing the importance of stability in the galaxy, offered their support in maintaining order and preventing chaos from engulfing the stars. <br>Together, they orchestrated a masterful plan, leveraging the Artefact's power to bring about positive change throughout the galaxy. With precision and finesse, they directed its energies towards rebuilding war-torn worlds, providing aid to those in need, and fostering cooperation among the various factions.

As they worked tirelessly to implement their vision of a brighter future, Captain Alex felt a sense of pride and satisfaction wash over him. The power of the Artefact, once a source of fear and uncertainty, had become a force for good, a beacon of hope in a galaxy plagued by darkness.
->END
==Fight1vs1==
~sceneSetting="fight1vs1"
~music="fight1vs1"
Using the new Jammer Technology powered by the Artefact, Alex navigated the labyrinthine corridors of Varek's base with precision, evading detection on Varek's Radars. As he delved deeper into the stronghold, his senses heightened, searching for any sign of Varek's whereabouts and the location of his captured partner, Zara. <br>With each step, Alex felt the weight of his mission pressing down upon him, but he remained steadfast, his determination unwavering. Finally, after what seemed like an eternity, he stumbled upon a set of encrypted terminals, their screens flickering with data, that were the main Terminal in the building. .

Alex tried to breakthrough the encryption methods and he managed to do this with success. He got the coordinates of Varek's location and decided to use the Teleporter. 
*[Continue]->Fight
->END

==Fight==
~sceneSetting="fight"
~music="fight"
In a split a second, Alex was inside Varek's Main Room, where he stood on a throne and Zara laying down on the floor exhausted and unconscious. <br>The air crackled with tension as Alex and Varek, archrivals bound by destiny, faced each other in the heart of Varek's stronghold. Their eyes locked in a silent exchange of determination and resolve, each prepared to lay everything on the line in the ultimate test of strength and will.

With a thunderous clash of metal, they launched into battle, their movements a blur of precision and power. Alex's blade danced with the grace of a seasoned warrior, while Varek's strikes were fueled by a relentless fury born of desperation. <br>With every clash, sparks flew, illuminating the darkness with a fierce brilliance. Neither combatant yielded an inch, locked in a primal struggle for dominance that echoed through the corridors of the fortress. <br>As the battle raged on, it became clear that only one would emerge victorious, their fate intertwined with the destiny of the galaxy itself. <br>Alex, hiding behind a pillar, understood that he can't win Varek without his technology, he decided to use the Artefact.

He redirected the power to his swords sharp edge making it incredibly deadly and powerful, and in a desperate final attack caught Varek by surprise and pierced his body, marking the winner in this battle. But Varek in a final move reached for Alex's blade and destroyed the link between the Artefact and Blade, overloading it. <br>Blade started to fade out in a bright light, Alex tried to remove it, but his motions were too clumsy and the blade exploded leaving Alex badly wounded and Varek completely desintegrated in the air, with some body parts thrown on the cold floor.
*[Continue]->NeutralEnding1

->END
==BecomeAnti==
~sceneSetting="becomeAnti"
~music="becomeAnti"
As he closed in on Varek's base, a primal fury ignited within him, fueling his aggression and drowning out any semblance of reason or restraint. <br>With a burst of energy, Alex launched himself into the heart of the base, his ship weaving through enemy fire with impossible grace. Blasts of energy streaked past him as he closed the distance, his focus singular and unwavering. <br>With every step deeper into Varek's fortress, Captain Alex's heart pounded with a mixture of anticipation and dread. Finally, he stood face to face with his nemesis, their eyes locking in a silent exchange of hatred and determination. With a primal roar, they lunged at each other, their blades clashing in a symphony of steel and fury.

In the heat of battle, Alex felt the weight of years of conflict bearing down upon him, driving him to fight with a ferocity he had never known. Every strike, every parry, was fueled by the burning desire to see Varek brought to justice and Zara freed from his clutches. <br>Yet as the battle raged on, a realization began to dawn upon Alex – Varek was not just his enemy, but a mirror reflecting the darkness within himself. With every blow exchanged, he felt the line between righteousness and vengeance blurring, his soul consumed by the same ruthless thirst that drove Varek. <br>As Alex stood victorious above Varek, his chest heaving with exertion, he heard the last words of his opponent, a chilling whisper that sent shivers down his spine. But before he could fully comprehend their meaning, a surge of primal rage surged through him, clouding his thoughts and distorting his senses.

In that moment, Alex was no longer the man he once was. He was a creature of raw instinct and unbridled fury, a monster unleashed upon the world. His hands trembled with the urge to strike, his mind consumed by the desire to extinguish the last flicker of life from his fallen foe. <br>With a savage cry, Alex plunged his blade into Varek's heart, the sound of flesh tearing drowned out by the roar of his own bloodlust. Again and again, he struck, each blow fueled by the darkness that writhed within him, until Varek's lifeless body lay at his feet, a testament to the depths of his descent into madness.

As Zara looked on in horror, her eyes wide with disbelief and fear, she realized that the man standing before her was no longer the Alex she knew. He was a stranger, a monster wearing the guise of her friend, and she knew that she could no longer trust him. <br>In that moment of brutal violence, something within Zara shifted, a seed of doubt planted deep within her heart. She knew that the man she had once called friend was gone, replaced by a shadow of his former self, consumed by the darkness that now threatened to consume them all. And as they left the chamber behind, the weight of what she had witnessed hung heavy upon her soul, a silent reminder of the dangers that lurked within the depths of human nature.
*[Continue]->NeutralEnding2

->END
==LoseArtifact==
~music="loseArtifact"
~sceneSetting="loseArtifact"
In the final, decisive battle, the clash between Alex's forces and Varek's resistance erupted into a cataclysmic symphony of destruction. The air crackled with the hum of energy weapons, the ground trembled beneath the thunderous roar of explosions, and the sky was painted with streaks of fire as ships engaged in fierce dogfights above. <br>As the battle raged on, Alex found himself locked in a fierce duel with Varek himself, their blades clashing with a fury born of years of bitter rivalry. Each blow was met with equal ferocity, neither combatant willing to yield an inch in their relentless pursuit of victory.

But as the tide of battle turned in Alex's favor, a sense of grim determination settled over him. With every strike, he felt the weight of the galaxy's hopes and dreams resting on his shoulders, a burden he bore with unflinching resolve. <br>And then, in a single, decisive moment, Alex delivered the crushing blow that brought Varek to his knees, his defeat echoing through the silent chamber. But victory came at a price – the toll of the battle was etched in the scars that marred Alex's body and soul, a reminder of the sacrifices made in the name of peace.
*[Continue]->NeutralEnding3
->END
==ArtefactvsZara==
~music="artefactVSzara"
~sceneSetting="artefactVSzara"
Faced with the weight of his choices, Alex stood at a crossroads, torn between two paths, each fraught with sacrifice and uncertainty. <br>With the Artefact in his possession, he held the power to end Varek's reign of terror once and for all, but at the cost of Zara's life. <br>Alternatively, surrendering the Artefact to Varek offered the chance to save Zara, but at the risk of unleashing untold devastation upon the galaxy. <br>What would you choose? Love or Peace?
*[Use Artifact]->UseArtefact
*[SaveZara]->SaveZara
->END

==NeutralEnding1==
~music="neutralEnding1"
~sceneSetting="neutralEnding1"
As the dust settled and the echoes of battle faded, Captain Alex lay on the cold floor of Varek's stronghold, his body battered and broken. The once-mighty Artefact, now shattered and spent, lay scattered around him, its power extinguished in a blinding burst of light. <br>Through the haze of pain and exhaustion, Alex felt a gentle touch on his shoulder. With a start, he opened his eyes to see Zara kneeling beside him, her expression one of concern and relief. <br>"Alex," she whispered, her voice a soothing balm to his wounded spirit. "You're alive."

With a grimace, Alex attempted to rise, but the pain lanced through his body, reminding him of the cost of victory. "We need to get out of here," he managed to say, his voice hoarse with exertion. <br>As they staggered towards the safety of their ship, Captain Alex's vision blurred and his strength waned with each step. <br>Despite Zara's unwavering support, Alex's body rebelled against him, every movement sending waves of agony coursing through his battered form. His limbs felt like lead, his breaths labored and shallow.

As they reached the safety of their ship, Alex collapsed onto the cold metal floor, his body trembling with exhaustion. With a heavy heart, he realized that he could no longer fight, his once formidable strength drained away by the merciless demands of war. <br>In that moment of vulnerability, Alex understood that even the greatest warriors must sometimes yield to their limitations, finding solace in the embrace of those who stand by their side. With Zara's steady presence as his anchor, he closed his eyes and surrendered to the healing embrace of sleep, knowing that tomorrow would bring new challenges, but also the promise of renewal and hope.
->END
==NeutralEnding2==
~music="neutralEnding2"
~sceneSetting="neutralEnding2"
As Alex had his Artefact, seduced by its power, and his new brutal nature, he became the sole authority in the galaxy. Having wielded unparalleled power, his commands echoed across the stars, bending all to his will. Yet amidst the whispers of obedience and the clamor of submission, one voice remained steadfast in its defiance – Zara, his once-loyal comrade and confidante. <br>With a keen eye and a sharp mind, Zara watched as the darkness consumed Alex, transforming him into a creature of merciless rage and unchecked brutality. She saw the flicker of humanity fade from his eyes, replaced by the cold, calculating gaze of a tyrant. <br>With a heavy heart and a resolve born of necessity, Zara made her decision – she could no longer stand by and watch as Alex's tyranny laid waste to everything they had fought for. In a final, desperate act of defiance, she turned her back on him and decided to kill him, leaving behind the echoes of their shared past and the shattered remnants of their friendship.
Gathering her courage, Zara confronted Alex in the heart of his fortress, her eyes filled with a mixture of sorrow and determination. As Alex turned to face her, a flicker of recognition flashed across his face before being swallowed by the shadows that clouded his mind. <br>With a steady hand and a heart heavy with regret, Zara raised her weapon, the weight of her decision bearing down upon her with each passing moment. She knew that there would be no turning back from this path, no redemption for either of them. <br>As the echoes of their shared past reverberated through the chamber, Zara's finger tightened on the trigger, the sound of gunfire shattering the silence like a thunderclap. In that moment, time seemed to stand still as the fate of the galaxy hung in the balance.

And then, it was over. As Alex's lifeless body crumpled to the ground, a sense of emptiness washed over Zara, mingled with a grim sense of satisfaction. The tyrant who had once been her friend was no more, his reign of terror brought to a decisive end.
->END
==NeutralEnding3==
~music="neutralEnding3"
~sceneSetting="neutralEnding3"
Reluctantly, Alex stood before the assembled leaders of the Galaxy Authorities, their demands echoing through the cavernous halls of power. They wanted the Artefact. <br>With a heavy heart, Alex knew that the Artefact was too dangerous to remain in the hands of the Galaxy Authorities. But as he watched them clamor for control, their eyes alight with greed and ambition, he couldn't shake the feeling that they had underestimated the true nature of the Artefact's power. <br>In the end, Alex agreed to their terms. But as he handed over the Artefact, a sense of foreboding settled over him, a nagging feeling that their actions would have far-reaching consequences.

Days turned into weeks, and Alex watched with growing concern as the Galaxy Authorities began to wield the Artefact's power with reckless abandon. Their attempts to harness its energies for their own ends bordered on madness. <br>And then, disaster struck. In a cataclysmic explosion, the Artefact overloaded, its power unleashed swept across the galaxy like a tidal wave. Cities crumbled, worlds burned, and the very fabric of reality seemed to unravel before Alex's eyes. The world has changed and it will never be the same


->END
==UseArtefact==
~music="useArtefact"
~sceneSetting="UseArtefact"
In the end, Alex made his decision. With a heavy heart and a resolve as unyielding as steel, he chose to use the Artefact to stop Varek, knowing that it would mean sacrificing Zara in the process. <br>As the Artefact unleashed its power, enveloping Varek and Zara in its, Alex watched with a mixture of grief and determination, knowing that he had made the ultimate sacrifice for the greater good. <br>As the dust settled and the echoes of battle faded, Alex stood alone amidst the wreckage of Varek's fortress, his heart heavy with the weight of his choices. <br>But even as he mourned the loss of Zara, he knew that her sacrifice had not been in vain. With Varek defeated and peace restored to the galaxy, her memory would live on as a beacon of hope in the darkness, a reminder of the price of freedom and the strength of love in the face of adversity.
*[Continue]->BadEnd1
->END
==SaveZara==
~music="saveZara"
~sceneSetting="saveZara"
Faced with an impossible choice, Alex weighed the options before him, each one fraught with its own consequences. <br>With a heavy heart and a sense of resignation, he made the decision to surrender the Artefact to Varek, knowing that it was the only way to ensure Zara's safe return. <br>As the Artefact changed hands, Alex felt a profound sense of uncertainty, knowing that he had sacrificed the entire Galaxy, not knowing fully what will happen in the future. But as Zara returned to his side, her presence a beacon of hope in the darkness, he knew that some sacrifices were worth making. <br>Together, Alex and Zara faced the uncertain future that lay ahead, united in their determination to overcome whatever challenges awaited them. 
*[Continue]->BadEnd2
->END

==BadEnd1==
~music="badEnd1"
~sceneSetting="badEnd1"
In the aftermath of the fateful decision to sacrifice his significant other for the sake of galaxy's balance, Alex found himself consumed by a profound sense of regret and sorrow. The weight of his choice hung heavy upon his shoulders, casting a shadow over every aspect of his life. <br>Despite the victory and peace that had been achieved, the cost had been unbearably high – the loss of someone he held dear. <br>Haunted by memories of what could have been and tormented by the echoes of his past actions, Alex struggled to find solace in the wake of his sacrifice. The galaxy may have been saved from the brink of destruction, but at what cost? The emptiness that gnawed at his heart served as a constant reminder of the profound loneliness that now defined his existence.

As he wrestled with the demons of his own making, Alex grappled with the unanswerable question – was it worth it? To sacrifice love for the greater good, to bear the burden of responsibility for the lives of countless others? The answer eluded him, lost in the depths of his own anguish.
->END

==BadEnd2==
~music="badEnd2"
~sceneSetting="badEnd2"
As Varek seized control of the Artefact, its power coursing through him like a dark and unstoppable force, the galaxy trembled beneath his iron grip. With the might of the Artefact at his command, he subjugated the Galaxy Authorities, bending them to his will and extinguishing any semblance of resistance. <br>The galaxy descended into chaos and despair. Freedoms were crushed and the hopes of countless beings were snuffed out in the relentless pursuit of power. Varek's reign of terror knew no bounds, his thirst for domination driving him to ever greater heights of cruelty and oppression. <br>As the galaxy languished under Varek's rule, Alex and Zara found themselves in a hopeless position to fight against Varek, but at least they are together for the end of their lives.
->END
