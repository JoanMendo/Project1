# Proyecto 1 - Pantone

Proyecto de test de daltonismo gamificado para generar un diagnóstico de manera cómoda y entretenida. 

El juego trata de un laberinto, en el cual el jugador deberá buscar la salida correcta para ir al siguiente nivel, cada nivel tiene dos salidas:

Salida camuflada: Esta salida estará marcada con un color que la gente con determinados tipos de daltonismo no puede distinguir del resto de las paredes del laberinto y el jugador está forzado a verla al seguir el camino hacia la otra salida.
Salida clara: Esta salida será clara para todo el mundo, pero será la única salida que la gente con el tipo de daltonismo del nivel verá.

El juego comienza en con una pantalla para introducir el nombre, el género biológico y la edad del jugador. Con estos dos últimos, las diferentes salidas tomadas, el tiempo tardado en cada nivel y el numero de veces que ha muerto en dicho nivel, realizaremos un diagnóstico de daltonismo y lo mostraremos al final al jugador. También guardaremos los datos en una API por si se necesitan revisar más adelante.

Después de introducir los datos, se empieza un nivel inicial que servirá como tutorial de lo que se tiene que hacer. Una vez acabado el tutorial, el jugador ha de completar 12 niveles (WASD para moverse), cada uno con su tipo o tipos de daltonismo asignado. Para complicarlo un poco el laberinto estará completamente a oscuras, exceptuando un área alrededor del personaje, y las paredes exteriores restaran vida al personaje. Si la barra de vida del jugador se vacía, el personaje volverá al punto de inicio el nivel.

De los 12 niveles, 4 son de tritanopia, 3 niveles son de protanopia, 3 son de deuteranopia y 2 son de protanopia y deuteranopia.
