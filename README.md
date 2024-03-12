# Codes SMELLS : 

-  Variables publiques : quiterJeu et tourDuJoueur sont publics, ce qui va à l'encontre de l'encapsulation. 

-  Duplication de code : Les méthodes tourJoueur et tourJoueur2 sont presque identiques, à l'exception du caractère utilisé pour le joueur. Ce type de duplication pourrait être réduit en paramétrisant la différence ou en extrayant le comportement commun dans une méthode séparée.

-  Gestion de l'état du jeu dans la boucle principale : La réinitialisation de la grille à chaque tour de la boucle principale (BoucleJeu) pourrait être évitée 

-  Logique de contrôle de flux complexe : L'utilisation de goto pour gérer les entrées utilisateur dans BoucleJeu est généralement considérée comme une mauvaise pratique.

-  Mauvaise gestion de la grille : Dans la méthode affichePlateau, il y a une erreur d'affichage de la grille ({grille[2, 0]} | {grille[1, 1]} | {grille[0, 2]} devrait probablement être {grille[2, 0]} | {grille[2, 1]} | {grille[2, 2]})

-  Manque de modularité : Les vérifications de victoire (verifVictoire) et d'égalité (verifEgalite) sont intégrées dans des méthodes booléennes spécifiques, mais la manière dont elles sont codées (avec de longues lignes de conditions) rend le code difficile à lire. 

-  Noms de méthodes et de variables : L'utilisation du français pour les noms des méthodes et des variables (par exemple, quiterJeu, BoucleJeu, tourJoueur) est acceptable mais peut poser des problèmes de cohérence et de compréhension pour des développeurs

-  Initialisation redondante de la grille : La grille est initialisée dans le constructeur, puis à nouveau au début de chaque partie dans BoucleJeu. Cette redondance pourrait être éliminée ou gérée différemment pour optimiser l'initialisation.

-  Manque d'abstraction : La classe pourrait bénéficier d'une meilleure abstraction en séparant la logique du jeu (gestion du plateau, vérification des conditions de victoire, etc.) de l'interaction avec l'utilisateur (affichage du plateau, saisie des mouvements). Cela rendrait le code plus réutilisable et plus facile à maintenir.

-  Logique métier étroitement couplée à l'interface utilisateur : La logique de jeu (par exemple, vérification de la victoire, gestion des tours) est étroitement liée à la console et à la saisie utilisateur. Cela rend difficile la réutilisation du code dans des contextes différents.

-  Magic numbers : Le code utilise des nombres magiques 

-  Commentaires en bloc commentés : Le code contient des parties commentées 

---------------------------------------------------------------------------------------

# I - Les difficultés liées à la validation : 

-  Manque de modularité : Le code n'est pas suffisamment divisé en modules ou classes indépendantes, ce qui rend difficile l'isolation des fonctionnalités pour les tester de manière unitaire. Par exemple, si une fonction verifVictoire est directement intégrée dans un grand bloc de code sans séparation claire, cela rend les tests unitaires et la validation plus complexes.

-  Code fortement couplé : Des choix de design qui mènent à un couplage fort entre les composants du logiciel rendent difficile la modification d'une partie du code sans affecter les autres, ce qui complique les corrections de bugs et les mises à jour.

-  Exemple : Utilisation directe de tableaux multidimensionnels pour la grille de jeu, rendant les vérifications de victoire ou d'égalité complexes et sujettes aux erreurs



# II - Méthodes de résolution de ces problèmes

-  Refactoring pour plus de modularité : Diviser le logiciel en modules ou classes bien définis, chacun avec une responsabilité unique. Cela facilite la maintenance, la compréhension et les tests unitaires.

-  Mettre en place des tests automatisés : Développer un ensemble de tests automatisés à différents niveaux pour s'assurer de la non-régression et faciliter la validation des corrections et des nouvelles fonctionnalités.

-  Réduire le couplage : Refactoriser le code pour réduire les dépendances entre les composants. Utiliser des interfaces et des principes de design comme l'injection de dépendances pour faciliter cela.

-  Améliorer la gestion des erreurs : S'assurer que le logiciel gère correctement toutes les erreurs possibles et les entrées invalides, pour éviter des comportements inattendus.



# III - Développement des fonctionnalités manquantes

-  Intelligence Artificielle (IA) Basique : Commencer par une IA simple qui choisit des mouvements aléatoires valides. Cela permet d'avoir rapidement un adversaire automatique.
-  IA Avancée : Développer une IA plus avancée utilisant des algorithmes comme Minimax

-  Base de données ou fichiers : Utiliser des fichiers (JSON, XML) pour stocker l'historique des parties, les scores, et les états de jeu.
-  Implémentation : Implémentez les fonctions nécessaires pour enregistrer une nouvelle partie dans le système de stockage choisi, ainsi que pour lire les historiques de parties.

-  Sauvegarde : Mettez en place une fonction permettant de sauvegarder l'état actuel d'une partie en cours, y compris la disposition des jetons sur le plateau, le joueur actuel, etc.
-  Chargement : Implémentez une fonction pour charger un état de jeu sauvegardé afin de permettre aux joueurs de reprendre une partie interrompue.
