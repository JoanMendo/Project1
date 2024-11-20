# Proyecto 1 - Pantone

Proyecto de test de daltonismo gamificado para generar un diagnóstico de manera cómoda y entretenida. 

El juego trata de un laberinto, en el cual el jugador deberá buscar la salida correcta para ir al siguiente nivel, cada nivel tiene dos salidas:

Salida camuflada: Esta salida estará marcada con un color que la gente con determinados tipos de daltonismo no puede distinguir del resto de las paredes del laberinto y el jugador está forzado a verla al seguir el camino hacia la otra salida.
Salida clara: Esta salida será clara para todo el mundo, pero será la única salida que la gente con el tipo de daltonismo del nivel verá.

El jugador se moverá por los niveles utilizando las teclas WASD. Si el jugador choca con una pared exterior, el personaje perderá una vida. Si el jugador pierde 3 vidas, el personaje volverá al punto de inicio el nivel.

Al comienzo del juego se le pregunta al jugador el nombre, el género biológico y la edad. Con estos dos últimos, las diferentes salidas tomadas, el tiempo tardado en cada nivel y el numero de veces que ha muerto en dicho nivel, realizaremos un diagnóstico de daltonismo y lo mostraremos al final al jugador. También guardaremos los datos en una API por si se necesitan revisar más adelante.
