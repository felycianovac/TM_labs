VAR eng = 0
VAR com = 0
VAR dip = 0
VAR knows_binefactor = false
VAR knows_pirates = false
VAR knows_artifact_legend=false

->Introduction
==Introduction==
As the ship hums quietly against the backdrop of the cosmos, I take a moment to reflect. "I'm Alex," I think to myself, "a spacefarer, a seeker of the lost and the hidden. I left the familiar behind a long time ago, chasing whispers on the edge of the unknown. Some call it a lonely path, but out here, among the stars, I'm more at home than I ever was on solid ground." <br>The Oddyssey, my trusty vessel, has been more than just a ship to me. "Just me and you, Zara" I say, glancing at the AI's interface that lights up in response.<br>It's funny how the vastness of space can make you introspective. Each planet, each asteroid field, every nebula I've encountered, has been a teacher of sorts. I've learned about resilience in the face of the eternal night, about wonder, and about the kind of peace you can only find when you're light-years away from everything else.
*[Continue]
->VarekIntroduction #image1
    -> END
==VarekIntroduction==
Suddenly, on the screen in the ship appears a new signal - call from a guy named "Varek". You decide to answer the call and Varek asks you to give him the artefact on friendly terms (pe cale pasnica).
*[Give artefact to Varek]
->GiveArtefact
*[Keep artefact on the ship]->ZaraStealing
->END

==GiveArtefact==
You decide to follow Varek's Instructions. You try to say him that you want to collaborate and give him the artefact, but something you is stopping you - you cant accept his offer.

Are you sure about that?
*[Yes]->WorstEnding
*[No]->VarekIntroduction
->END

==WorstEnding==
Alex decided to give the artefact to Varek. Varek greets Alex's collaboration and invites him to meet the ship at a hidden station. While approaching the station some bad feeling appears in your heart, but there is no way of coming back. Varek meets Alex, they exchange the artefact, and while Alex was getting to the ship, Varek shoots and blows up Alex and his ship.

Epilogue: Varek uses the power of artefact to gain a lot of power and influence in the galaxy - becomes the lord of the galaxy and brings tiranny in this shattered world

YOU LOST!
-> END
==ZaraStealing==
You decide to keep artefact on your ship, which enrages Varek and suddenly the call is ended with his words: "You will regret this unwise decision!".

Alex decides to return to his space station and sees a mess and only destruction. You find all your crews ships destroyed, except your partner Zara - she disappeared. You decide to retrieve some data from a survived black box the ships of your crew and hear last few minutes of their life, which ended in a heavy firefight with an unknown group of militants. Last sequence of the data signalize that Varek was there searching for location of the signal of Alex ship in order to get the Artefact, but he got no success, so he decided to take your companion with you so that you will follow him further by yourself
*[Return to Alex ship]->ShipReturn
->END

==ShipReturn==
After a tense encounter with Captain Varek, where he takes Zara as leverage to compel Alex to surrender the artifact—which Alex refuses—Alex feels the weight of solitude in the cockpit. The Odyssey, once filled with Zara's presence, now echoes with an unsettling silence.
*[Try to track down Varek]->TrackVarek

*[Investigate Artefact]-> InvestigateArtefact
->END

==TrackVarek==
~ eng+=1
~ dip+=1
Alex decides that Zara's safety and the strategic advantage of the artifact are paramount. However, the attempt to track down Zara is unsuccessful due to Varek's elusive tactics, forcing Alex to reconsider the immediate plan of action for the artifact.

In the wake of the failed attempt to locate Zara, a mysterious benefactor reaches out to Alex.

The benefactor claims to have extensive knowledge about the artifact. Additionally, the benefactor offers strategic intelligence on Captain Varek, indicating a deep familiarity with Varek's operations and possibly a personal vendetta against him.

Furthermore, the benefactor proposes help in recovering Zara from Varek's clutches, hinting at having resources or contacts that could facilitate a rescue mission or negotiate her release. This aspect of the offer directly appeals to Alex's immediate concern for Zara's safety.

Despite the potential benefits, the benefactor's offer is laden with ambiguity. Alex is left to ponder the risks of accepting help from an unknown entity, weighing the advantages of gaining a powerful ally against the possibility of being manipulated for the benefactor's undisclosed goals.
*[Accept the Benefactor's Offer]->AcceptOffer
*[Decline Offer]->DeclineOffer
->END

==InvestigateArtefact==
~eng+=2

Uncover Alien Tech

Alex chooses to delve deeper into the mysteries of the artifact, prioritizing the pursuit of knowledge and the potential benefits it could bring, despite the risks involved.
*[Develop a New Tool or Weapon]->DevelopTool
*[Integrate Ship]->IntegrateShip
->END

==AcceptOffer==
~dip+=3
~eng+=2
~knows_binefactor=true
Despite uncertainties about the benefactor's true intentions, Alex decides to accept the offer, hoping the additional support will provide a strategic advantage in the quest to recover Zara and deal with the artifact.
*[Continue]->Pirates
->END

==DeclineOffer==
Alex chooses to decline the benefactor's offer, driven by a mix of skepticism and a desire to maintain independence. This decision underscores Alex's resolve to face the challenges ahead without relying on uncertain alliances.

(Alex doesnt gain anti Varek allies in future)

He chooses to focus on strengthening ship etc.
*[Continue]->Pirates

->END

==DevelopTool==
~eng+=3
~com+=2
some text
*[Continue]->Pirates
->END

==IntegrateShip
~eng+=5
Choose to use the alien technology to upgrade your ship, significantly boosting its capabilities. This choice further increases your Engineering skill and may offer new gameplay mechanics, like enhanced travel or combat options.
*[Continue]->Pirates

->END
==Pirates==
some text
*[Trick Pirates and Escape]->TrickPirates
*[Fight Off Pirates]->FightPirates
*[Negotiate Peace and create allies]->NegotiatePeace
->END

==TrickPirates==
~eng+=2
~com+=1


Develop Stealth Tech for Ship
*[Develop Countermeasures]->DevelopCounter
*[Improve Ship's stealth capabilities]->ImproveShip
->END
==FightPirates==
~com+=3
Salvage Pirate Tech and Data. Alex has time only for one decision
*[Stealth Tech Development]->StealTechDev
*[Recover Data]->RecoverData
*[Combat Upgrade from Salvaged Tech]->CombatUpgrade
->END
==NegotiatePeace==
~dip+=3
~knows_pirates=true
Pirates Offer a Map to a Hidden Base (?)
*[Combat Training]->CombatTraining
*[Explore Hidden Base]->ExploreHidden
->END

==StealTechDev==
~eng+=3
~com+=2
some text
*[Plan Varek Encounter]->PlanVarek
->END
==RecoverData==
~knows_artifact_legend=true
some text
*[Plan Varek Encounter]->PlanVarek
->END
==CombatUpgrade==
~com+=4
some text
*[Plan Varek Encounter]->PlanVarek
->END

==CombatTraining==
~dip+=4
~knows_artifact_legend=true
some text
*[Plan Varek Encounter]->PlanVarek
->END

==ExploreHidden==
some text
*[Plan Varek Encounter]->PlanVarek

->END
==DevelopCounter==
~eng+=2
~com+=2
Work on specific countermeasures against pirate tactics, such as electronic decoys or improved shields, enhancing both Engineering and Combat skills.
*[Plan Varek Encounter]->PlanVarek
->END
==ImproveShip==
~eng+=3
Decide to upgrade your ship's stealth systems to better avoid future confrontations, making it harder for enemies to detect or track you.
*[Plan Varek Encounter]->PlanVarek
->END

==PlanVarek==
some text
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
