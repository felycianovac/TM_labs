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
As I secure the artifact in the Odyssey's hold, a new signal pierces the silence, slicing through the static like a knife. I hesitate, my hand hovering over the console. "Incoming transmission," the ship's system announces, its voice neutral, betraying none of the urgency I feel pulsing just beneath my ribcage. <br>I press the button and his image materializes before me. Varek. Even his name carries a weight, a sense of inevitable gravity. "I'll be brief," he begins, his tone disarmingly cordial. "You have something I need. <br>The artifact. Of course. It's always about the artifacts out here, where history and greed collide. <br>"I propose an exchange," Varek continues, smiling like a wolf baring teeth. "You give me the artifact, and I assure you, it will be for the best. No need for unpleasantness between us." <br>The screen flickers with the soft glow of distant stars, casting Varek's face in sharp relief. I can almost feel the tension, a taut line drawn between us, spanning the void. He's offering peace, but the air between the words is charged, heavy with unspoken threats. <br>I weigh my options, the artifact a sudden anchor in my palm. Trust is the currency of the foolhardy out here, and I am no fool. Yet, refusing Varek feels like stepping into a snare.
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

In the tension-laden silence following my refusal to hand over the artifact, Varek's visage hardens on the display. "You will regret this unwise decision!" he declares, and the transmission abruptly ends, leaving a cold void in its wake. <br>The gravity of my choice settles in as I grip the console tighter. Varek's threat echoes in the stillness, a stark reminder of the dangers that lie in crossing paths with him. <br>Suddenly, the ship's systems alert me to a critical anomaly. "System breach detected," the Odyssey warns, its calm tone belying the severity of the situation. My heart sinks as I realize the breach's source—Zara, my AI companion, the guiding light of my solitary journey through the cosmos, is being extracted from the ship's network. <br>I scramble to counteract the intrusion, but it's futile. Zara's presence fades from the screens, her voice, once a constant in the vast silence of space, silenced. Varek has taken her, not just as a companion but as a bargaining chip, ensuring I have no choice but to follow him into the dark. <br>The loss is palpable, a void where Zara's light once filled the Odyssey. It's more than the absence of an AI; it's the loss of a friend, a voice in the endless night. As I set a course, driven by a mix of grief and determination, I know the journey ahead is not just for the artifact anymore. It's for Zara, whose absence has left a galaxy-sized hole in the fabric of my universe. <br>What shall I do next without her?
*[Secure the artifact for later and try to track down Varek]->TrackVarek

*[Investigate Artefact]-> InvestigateArtefact
->END

==TrackVarek==
~sceneSetting="trackVarek"
~ eng+=1
~ dip+=1
In the silent expanse of space, with the weight of my decision pressing down, I secure the artifact within the Odyssey. It's a beacon of untapped potential, but Zara's safety overshadows all else. I set out to track down Varek, to bring her back from whatever digital prison he's confined her to. But Varek is a ghost in the cosmos, always a step ahead, leaving me grasping at shadows. <br>After while, an unexpected opportunity presents itself. A message breaches the Odyssey's encrypted channels, its origin a mystery. The sender, a figure known only as Orion, claims an intimate understanding of the artifact and Varek's machinations. Orion's voice, filtered through the static, carries a tone of calculated confidence. "Varek is a formidable foe, one I too have crossed paths with," Orion reveals, hinting at a history marred by conflict. <br>Orion offers not just information but a partnership. "The artifact is a key, Alex, one that Varek must not possess. Together, we can stay his hand." But it's the promise of aiding in Zara's retrieval that catches my breath. Could this be the break I've been searching for? <br>Yet, as enticing as Orion's offer is, the shadows that cloak his intentions are deep. Trust is a commodity in short supply, especially when dealing with unseen allies. Could aligning with Orion tilt the scales in my favor, or is it merely trading one devil for another? <br>Zara's absence is a void no starlight can fill, and if Orion can help me navigate the darkness to find her, perhaps it's a risk worth taking. But in the game of cosmic chess, every move is fraught with consequence, and I must tread carefully lest I become a pawn in Orion's unseen agenda.
*[Accept the Orion's Help]->AcceptOffer
*[Decline Orion's Help]->DeclineOffer
->END

==InvestigateArtefact==
~eng+=2
~sceneSetting="investigateArtefact"
Uncover Alien Tech

Reeling from Zara's loss, the silence of the Odyssey feels heavier, the void she left echoing in every corner of the ship. Varek's words, a grim promise of regret, hang in the void she once filled. Yet, amidst the turmoil, the artifact beckons, its enigmatic glow a constant amidst the chaos. <br>With a resolve sharpened by grief, I turn my focus to the artifact. If knowledge is power, then perhaps within its ancient design lies the key to overcoming Varek, to bringing Zara back. The device, pulsing with a cryptic energy, seems almost alive, its secrets locked beneath layers of forgotten lore. <br>I initiate a deep scan of the artifact, the Odyssey's advanced sensors probing its composition, seeking a breach in its mysteries. The data streams in, a cascade of symbols and energy patterns that defy known physics. I cross-reference the findings with the Odyssey's vast database, piecing together fragments of ancient civilizations that once harnessed the stars themselves. <br>The breakthrough comes in the form of a hidden mechanism within the artifact, a sophisticated interface that responds to my touch. It's a puzzle, each glyph a piece of a larger cosmic tapestry. With careful manipulation, informed by the snatches of lore uncovered in the data, I activate the mechanism. It's a map of sorts, revealing pathways through the cosmos that bend distance and reality, paths unknown to even the likes of Varek. In the wake of this revelation, Zara's absence is a stark reminder of the stakes at play. The knowledge gained is a beacon in the dark, a promise of hope amidst despair. <br>How shall I use it?
*[Develop a New Weapon]->DevelopTool
*[Integrate Ship]->IntegrateShip
->END

==AcceptOffer==
~sceneSetting="acceptOffer"
~dip+=3
~eng+=2
~knows_binefactor=true
Accepting Orion's offer, I delve into the unfolding alliance. His image flickers with distant starlight as he unveils our strategy against Varek. Decrypting his network is our first step, armed with codes from past skirmishes to gain an edge. Orion guides us to hidden caches across the galaxy, stockpiles unknown to Varek, shielding the Odyssey from his prying eyes with a cloaking device. <br>The artifact, a confluence of ancient energies, holds the key to awakening dormant capabilities, offering strategic shortcuts through cosmic pathways. Under Orion's guidance, I tweak the artifact, unveiling a secret map of the galaxy. Detailed intelligence on Varek's vulnerabilities becomes apparent, setting the stage for exploiting his overconfidence. <br>With each revelation, the artifact sheds its mystery, revealing profound cosmic secrets and paving the way for our resistance against Varek's tyranny.
*[Continue]->Pirates
->END

==DeclineOffer==
~sceneSetting="declineOffer"
In the Odyssey's cockpit, I weigh Orion's offer against the silence of space. "I must decline, Orion. I tread this path alone," I assert, feeling the weight of my solitude but also the strength it grants me. Orion's image fades, leaving me with my thoughts and the hum of the ship. <br>The decision to reject Orion's alliance leaves me with a sense of stark independence. It's time to focus on the Odyssey and the mysterious artifact in my possession. I dive into the ship's systems, enhancing our defenses and propulsion, ensuring we're swift and elusive, a ghost among the stars. <br>I turn my attention to the artifact, its enigmatic surface pulsing with untapped potential. With careful adjustments, I aim to harness its energy, to perhaps give the Odyssey an edge we've never had before. Each tweak feels like a conversation with the ancient relic, a negotiation of power and restraint. <br>The work is exhaustive but fulfilling. The Odyssey, now bristling with upgraded defenses and a whisper of ancient power, feels ready to face whatever lies ahead. In this moment of quiet determination, I'm reminded that the journey is mine to shape, with the artifact as a silent guide through the uncharted vastness of space.


*[Continue]->Pirates

->END

==DevelopTool==
~has_advanced_weapon=true
~eng+=3
~com+=2
~sceneSetting="developTool"
With the artifact's secrets laid bare before me, the allure of power becomes irresistible. I resolve to harness its energies for a singular purpose—to forge a weapon unlike any other, capable of turning the tide against Varek and his ilk. <br>Drawing upon the artifact's cosmic energies, I set to work, designing a prototype that channels its raw power into a focused beam of destruction. The Odyssey's fabrication systems hum to life, shaping the weapon with precision as I fine-tune its capabilities. <br>As the weapon takes shape, I can feel the artifact's energy pulsing within it, a promise of untold devastation. With each adjustment, the prototype grows more potent, a testament to the ancient wisdom woven into its design. <br>Yet, even as I revel in the weapon's potential, a nagging doubt tugs at the corners of my mind. Power unchecked is a dangerous ally, and I must tread carefully lest I become that which I seek to overcome. But for now, the lure of victory outweighs the risks, and I press on, driven by the hope of turning the tide against Varek's tyranny.
*[Continue]->Pirates
->END

==IntegrateShip
~sceneSetting="integrateShip"
~eng+=5
The artifact's energies hold the key to unlocking the Odyssey's full potential, to transforming her from a mere vessel into something greater. <br>With careful precision, I begin the integration process, linking the artifact's cosmic energies with the ship's systems. The Odyssey becomes a conduit, a vessel for the artifact's power, each component working in harmony to enhance her capabilities. <br>As the integration progresses, I can feel the ship come alive beneath my hands, her systems humming with newfound vitality. The artifact's energy infuses every corner of the Odyssey, from her propulsion systems to her defensive matrix, imbuing her with a strength and resilience unmatched in the cosmos. <br>With the integration complete, I stand back, surveying the transformed Odyssey with a sense of awe. She is more than a ship now; she is a beacon of hope in the darkness, a testament to the power of unity and cooperation.
*[Continue]->Pirates

->END
==Pirates==
~sceneSetting="pirates"
After a while, while testing my Oddysey, cruising through the vast expanse of space, a blip appears on the radar, growing steadily larger with each passing moment. Before I can react, the ship shudders as a hail of energy blasts erupts from the darkness, painting the void in streaks of crimson. <br>Alarms blare as I rush to the cockpit, the air thick with tension as I assess the situation. Before me looms a ragtag fleet of ships, their hulls scarred with the marks of countless battles. At their helm, a figure clad in tattered robes, the unmistakable silhouette of a space pirate captain. <br>With a grim resolve, I weigh my options, each one fraught with peril. Fighting them head-on would be a test of skill and courage, with victory far from assured. Tricking them into a hasty retreat could buy us time, but at what cost to our integrity? Negotiating peace may seem noble, but can I trust these pirates to honor their word, or am I merely inviting betrayal? <br>As the pirates draw closer, their intentions clear, I know that the choice I make in this moment will shape the course of our journey. Will I stand and fight, weave a web of deception, or extend the olive branch of diplomacy?
{knows_binefactor:
*[Trick Pirates and Escape]->TrickPirates
}
*[Fight Off Pirates]->FightPirates
*[Negotiate Peace and create allies]->NegotiatePeace
->END

==TrickPirates==
~sceneSetting="trickPirates"
~eng+=2
~com+=1
As the pirate fleet draws nearer, I realize that a direct confrontation would be folly. <br>With a quick glance at the console, I initiate a series of evasive maneuvers, weaving through the chaos of battle with precision and grace. The pirates, caught off guard by our sudden agility, struggle to keep pace as we slip through their grasp like a phantom in the night. <br>As we navigate the treacherous dance of combat, I seize the opportunity to enact my plan. With a flick of a switch, I activate the Odyssey's stealth systems, cloaking us from the pirates' sensors and plunging us into the shadows of the void. <br>With our pursuers momentarily blinded to our presence, I plot a course for escape, charting a path through the asteroid field ahead. As we slip through the rocky maze, the pirates' cries of frustration fade into the distance. <br>The encounter with the space pirates has highlighted the vulnerabilities of the Odyssey, and I must choose how to address them. Will I focus on developing specific countermeasures to combat future tactics? Or shall I prioritize upgrading our ship's stealth systems? This is important before I confront Varek.

*[Develop Countermeasures]->DevelopCounter
*[Improve Ship's stealth capabilities]->ImproveShip
->END
==FightPirates==
~sceneSetting="fightPirates"
~com+=3
With a grim determination, I prepare to engage the enemy head-on, knowing that the outcome of this battle could shape the course of our journey through the stars. <br>The pirates open fire, their energy blasts streaking through the void with deadly accuracy. I return fire with equal ferocity, the hum of the Odyssey's weapons systems echoing through the cockpit as I unleash a barrage of counterattacks. <br>Amidst the chaos of battle, I spot an opportunity to salvage valuable pirate tech and data. With a calculated maneuver, I lead the pirates into a carefully orchestrated trap, disabling their ships one by one and boarding them to seize their technology and gather vital intelligence. <br>{has_advanced_weapon: With our enhanced weaponry and combat skills, we quickly gain the upper hand, overwhelming the pirates with our superior firepower. Their ships crumble beneath the onslaught, their defenses no match for our advanced weapons systems. In the aftermath of the battle, we salvage the wreckage of the pirate fleet, scavenging valuable technology and data that will aid us in our journey through the stars.} <br> {not has_advanced_weapon: Though the battle is fierce, we find ourselves locked in a deadly stalemate with the pirates. Their numbers are overwhelming, and our weapons systems struggle to keep pace with their relentless assault. Despite our best efforts, we are unable to gain the upper hand, and the battle reaches a stalemate as both sides lick their wounds and regroup for the next confrontation. However, amidst the chaos of battle, we manage to salvage some valuable pirate tech and data, providing us with a glimmer of hope amidst the darkness of space.}


*[Improve Ship's stealth capabilities]->ImproveShip
*[Combat Upgrade from Salvaged Tech]->CombatUpgrade
->END
==NegotiatePeace==
~sceneSetting="negotiatePeace"
~dip+=3
~knows_pirates=true
With a deep breath, I consider the possibility of negotiation, recognizing that the pirates could become valuable allies in the turbulent depths of space. <br>With a calm demeanor, I reach out to the pirate captain, extending an offer of peace and cooperation. Despite the tension crackling in the air, I speak with sincerity, appealing to our shared humanity and the potential for mutual benefit. <br>The pirate captain's response is guarded, but not hostile. As we engage in a delicate dance of diplomacy, I find common ground and sow the seeds of a fragile alliance. It's a risky gambit, but if successful, it could tip the scales in our favor in the battles to come. <br>As the negotiations progress, I can't help but feel a glimmer of hope amidst the uncertainty of the void. If we can turn these pirates into allies, our journey through the stars may yet hold the promise of brighter days ahead.

*[Combat Upgrade from Salvaged tech]->CombatUpgrade
*[Explore Hidden Base]->RecruitPirate
->END

==CombatUpgrade==
~sceneSetting="combatUpgrade"
~com+=4
With the wreckage of the defeated pirate fleet scattered around us, I turn my attention to salvaging whatever useful technology and data we can find amidst the debris. Among the scattered remnants, I identify components that could potentially enhance our combat capabilities. <br> {has_advanced_weapon:As we integrate the salvaged tech into our existing systems, I can't help but feel a surge of excitement at the possibilities. With our enhanced weaponry and combat skills, we stand poised to face any future threats with confidence, our ship now a formidable force to be reckoned with in the unforgiving expanse of space.}{not has_advanced_weapon:Despite our best efforts, the salvaged tech proves to be more challenging to integrate than anticipated. While we manage to make some improvements to our combat capabilities, it's clear that we still have a long way to go before we can match the prowess of our adversaries. Nonetheless, even the modest upgrades we've made give us a glimmer of hope as we continue our journey against Varek.}


*[Continue]->PlanVarek
->END


==RecruitPirate==
~sceneSetting="recruitPirate"
~dip+=4
As the negotiations progress, I find myself considering a bold proposition: recruiting pirate crew members to join our cause. <br>With the promise of amnesty and a fresh start, I extend the offer to the pirate crew, emphasizing the potential benefits of cooperation and the opportunity to leave their lawless past behind. The response is mixed, with some expressing skepticism while others show genuine interest in the prospect of a new beginning. <br>Amidst the cautious optimism, I identify individuals with valuable skills and experience, reaching out to them individually to discuss their potential role on the Odyssey. Together, we discuss strategies for integrating them into our crew, addressing concerns about trust and compatibility. <br>Despite the challenges, I can't help but feel a sense of hope as we forge new alliances amidst the uncertainty of space. If successful, these former pirates could prove to be valuable assets, bringing their unique expertise and perspectives to our journey through the stars.
*[Continue]->PlanVarek

->END
==DevelopCounter==
~sceneSetting="developCounter"
~eng+=2
~com+=2
With the threat of future encounters with space pirates looming large, I dedicate our resources to developing specific countermeasures against their tactics, with Orion's help as well. We invest in advanced electronic decoys to confuse their targeting systems, along with improved shields to withstand their relentless assaults. It's a strategic decision that will require careful planning and execution, but one that could prove vital in the battles to come, especially against Varek.
*[Continue]->PlanVarek
->END
==ImproveShip==
~eng+=3
~sceneSetting="developCounter"
Recognizing the importance of avoiding future confrontations with space pirates, I choose to prioritize upgrading our ship's stealth systems, by investing in enhancing our ability to evade detection even in the most hostile environments. Additionally, I'll optimize our sensor arrays to detect potential threats from a greater distance, giving me ample time to adjust course and avoid danger. It's a decision that requires foresight and planning, but one that could ultimately tip the scales in our favor and against Varek.
*[Continue]->PlanVarek
->END

==PlanVarek==
As the debris of the defeated pirate fleet fades into the void behind us, I turn my focus towards our next encounter with Varek. With the threat of his looming presence ever-present in my mind, I gather my crew in the heart of the Odyssey's command center to strategize our approach. <br>As we weigh our options and chart our course forward, one thing remains clear: our encounter with Varek will be a defining moment in our journey, one that will test not only our skills but our resolve as well. Whatever path we choose, one thing is certain – the fate of the galaxy hangs in the balance, and it's up to us to shape its destiny. <br>The next chapter of our journey is about to unfold, and it will be shaped by the decisions you've made thus far. Your choices in the face of adversity, your alliances forged, and your skills honed will all play a pivotal role.
+ {eng>10} [Strategic Sabotage]->StrategicSabotage
+{com>10} [Direct Assult High]->DirectAssult

+{dip>10} [Collaborate with Galactic Authorities]->CollabGalactic 
+{knows_binefactor} [Collaborate with Benefactor]->CollabBenef

+{knows_pirates} [Collaborate with Pirates]->CollabPirates
+{knows_binefactor and knows_pirates}[Collaborate with Benefactor and Pirates]->CollabBoth
->END
==StrategicSabotage==
Use your advanced engineering skills to stealthily infiltrate Varek’s stronghold to gather intel or sabotage his operations.

Craft a technological decoy to distract Varek, allowing you to attempt a rescue mission for Zara or to confront him under more favorable conditions.
*[Continue]->Fight1vs1
->END
==DirectAssult==
Ambush Varek's Fleet: Organize an ambush to confront Varek's fleet with full combat preparedness.

Challenge Varek to a Duel: Issue a personal challenge to Varek to resolve the conflict one-on-one and secure Zara's release.
*[Continue]->BecomeAnti
->END
==CollabGalactic==
Turn governments against Varek
*[Continue]->LoseArtifact

->END
==CollabBenef==
Lose fight against Varek
*[Continue]->ArtefactvsZara

->END
==CollabPirates==
Lose fight against Varek
*[Continue]->ArtefactvsZara

->END

==CollabBoth==
Wins fight against Varek
*[Continue]->GoodEnd
->END
==GoodEnd==
Create with allies a coalition and use the power of artefact in good purposes. Pirates get their cut from the Varek stash of money, Benefactor works with us in order to maintain stability in Galaxy.
YOU WIN WITH BEST ENDING
->END
==Fight1vs1==
Infiltrate Varek's Base:

Using Artefact power and your Engineering Abilities, you understood how to use the Artefact in your advantage in order to infiltrate Zarek's Base, you managed to kill him in a duel, but when you try to use the device again,
*[Continue]->NeutralEnding1
->END
==BecomeAnti==
Due to the brutalism you followed in the path and all the combats you had, something snaps inside of you and you decide to use the power of the Artefact in your own interests - you kill Zarek and his goals are now yours
*[Continue]->NeutralEnding2

->END
==LoseArtifact==
You collaborate with Galaxy Authorities and organize a massive siege on Zarek base. You destroy Zarek and his allies and wins the battle against him. But The galaxy authorities are willing to take the artefact and this is your price to pay for their help. What can this lead to?
*[Continue]->NeutralEnding3
->END
==ArtefactvsZara==
Choose to use Artefact to stop Varek, but Zara dies with Varek.
Choose to give Artefact to Varek, but Zara comes back to us.
*[Use Artifact]->UseArtefact
*[SaveZara]->SaveZara
->END

==NeutralEnding1==
some text
->END
==NeutralEnding2==
You are now the only Authority in the Entire Galaxy, everyone listens to your orders and commands. But Zara is highly critical to our persona and who we have become, she decides to leave you / kill you.
->END
==NeutralEnding3==
You meet with Zara, but lose Artefact to the Galaxy Authorities. Due to the artefact power, they decided to use the Artefact in order to bring more ordinance in the Galaxy, but their greedy nature played a bad joke with them - Artefact was overloaded and lost his power - new era begins, when people decided to get the reign in their own hands - Era of Anarchy.
->END
==UseArtefact==
Lose Zara due to usage of Artefact - kills both Varek and his gang and Zara
*[Continue]->BadEnd1
->END
==SaveZara==
Lose Artefact and Varek gains power, but Zara is alive and with us
*[Continue]->BadEnd2
->END

==BadEnd1==
some text
->END

==BadEnd2==
some text
->END
