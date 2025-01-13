# Projet_ProgrammationObjet_CSharp


Ce programme consiste à créer une base de données destiné à collectionner un ensemble de Personnages de l'univers du jeux-vidéo Honkai Star Rail.

J'ai récupéré les données de base sur Kaggle ici [Honkai Star Rail (Characters) - Kaggle](https://www.kaggle.com/datasets/ridhopandhu/honkai-star-rail-character-data/data), puis j'ai retouché les données.

La base de données est un fichier Json constitué des informations des Personnages.
Le fichier à charger pour remplir la base de données  est un fichier txt (la lecture du fichier JSON à un problème):

    Data/hsr_character-data.txt

C'est lui qu'il faut charger pour avoir une base de données bien remplie rapidement, sinon on peut toujours ajouter manuellement avec la commande add.


Liste des Personnages :
    march_7th
    dan_heng
    himeko
    welt
    kafka
    silver_wolf
    arlan
    asta
    herta
    bronya
    seele
    serval
    gepard
    natasha
    pela
    clara
    sampo
    hook
    luka
    qingque
    tingyun
    luocha
    jing_yuan
    blade
    sushang
    yukong
    yanqing
    bailu
    trailblazer_0
    trailblazer_1
    dan_heng_IL
    lynx
    fu_xuan


Liste des Paths (Voies) :
    preservation
    hunt
    erudition
    nihility
    destruction
    harmony
    abundance


Liste des types de combat :
    ice
    wind
    fire
    imaginary
    lightning
    quantum
    physical


Liste des raretés (en étoiles) des personnages :
    4
    5


⚠️ Attention :
Le séparateur entre chaque suite de textes entrée doit être la tabulation (il faut mettre une tabulation entre chaque argument, mais aussi à la fin de la commande : donc si on rentre en ligne de commande 1 seul argument comme help par exemple, il faut écrire help et faire une tabulation avant d'appuyer sur la touche Entrée et d'exécuter la commande !!)

Pour voir les warnings et erreurs :

    dotnet build HonkaiStarRail.csproj (il n'y a aucune erreur et aucun warning : tout est propre 👍 👌)

Pour lancer le programme :

    dotnet run HonkaiStarRail.csproj (une fois le programme lancé, on peut utiliser les commandes suivantes)



Commandes :

    help :
        Comportement : Afficher la documentation
        Arguments nécessaires :
            RIEN
        Arguments optionnels :
            RIEN

    loadtxt : (exemple, "loadtxt    Data/hsr_character-data.txt ")
        Comportement : Charger un fichier txt qui contient les information des Personnages. Les Personnages qui existent déjà dans la base de données seront sautés et les nouveaux Personnages seront ajoutés.
        Arguments nécessaires :
            1. Le chemin du fichier txt à charger

    loadjson : (exemple, "loadjson Data/hsr_character-data.json    ")
        Comportement : Charger un fichier Json qui correspond au format attendu. Les Personnages qui existent déjà dans la base de données seront sautés et les nouveaux Personnages seront ajoutés.
        Arguments nécessaires :
            1. Le chemin du fichier Json à charger

    add : (exemple, "add    kafka   4   hunt    ice ")
        Comportement : Ajouter un Personnage. Si un Personnage avec le même nom existe déjà dans la base de données mais avec des champs différents, son entrée sera réécrite.
        Arguments nécessaires :
            1. Nom du Personnage
            2. Rareté du Personnage
            3. Voie du Personnage
            4. Type de combat du Personnage
            Comme le séparateur est la tabulation, il est possible de mettre l'espace ou la ponctuation pour chaque argument.

    override : (exemple, "override  lynx    4   destruction fire    )
        Comportement : Mettre à jour les informations d'un Personnage. Si le Personnage n'exite pas déjà dans la base de données, une nouvelle entrée y sera créée avec les informations fournies.
        Arguments nécessaires :
            1. Nom du Personnage
            2. Rareté du Personnage
            3. Voie du Personnage
            4. Type de combat du Personnage
            Comme le séparateur est la tabulation, il est possible de mettre l'espace ou la ponctuation pour chaque argument.

    savejson : (exemple, "savejson  resultats.json  ")
        Comportement : Sauvegarde la base de données HonkaiStarRail en format Json dans un endroit spécifique (dossier Outputs). Si le chemin est le même que la base de données, le sauvegarde ne sera pas effectué afin de laisser la base de données intacte.
        Arguments nécessaires :
            1. Le nom du fichier Json

    savetxt : (exemple, "savetxt    results.txt ")
        Comportement : Sauvegarde la base de données en format Txt dans un endroit spécifique (dossier Outputs).
        Arguments nécessaires :
            1. Le nom du fichier Txt

    search : (exemple, "search   name   lynx    ", "search  rarity  5   ", ou encore "search    path    abundance")
        Comportement : Chercher un ou plusieurs Personnages et afficher ses ou leurs informations
        Arguments nécessaires :
            1. Le type de recherche : le type doit être l'un parmi "name", "rarity", "path", "type".
            2. Le motif de recherche :
                "name" : Pour trouver le Personnage qui porte ce nom
                "rarity" : Pour obtenir les Personnages qui ont cette rareté
                "path" : Pour visualiser tous les Personnages dont leur voie correspond
                "type" : Pour avoir tous les Personnages avec ce type de combat

    exit :
        Comportement : Terminer le programme
        Arguments nécessaires :
            RIEN
        Arguments optionnels :
            RIEN



Pour vous faire gagner du temps : tout fonctionne sauf le chargement du fichier JSON avec la commande "loadjson Data/hsr_character-data.json    ".

Quand on essaie de le charger, il n'y a pas d'erreurs qui s'affichent à proprement parlé, mais la base de données ne se charge pas à parti du fichier JSON car elle dit que les personnages du fichier JSON sont déjà présent dans la base de données même si c'est faux...

C'est pour ça que pour charger la base de données, on utilisera la commande "loadtxt    Data/hsr_character-data.txt ", qui fonctionne parfaitement !

Et encore une fois : ne pas oublier de faire des tabulations pour séparer chaque argument lors de l'appel de commande, mais aussi faire une tabulation à la fin de la commande avant d'appuyer sur la touche Entrée et d'exécuter la commande (ainsi, même la commande help qui n'attend aucun argument devra s'écrire "help    " par exemple, mais pas besoin pour exit).
