# Práctica 3 II: Delegados
## Autor: _Aarón José Cabrera Martín_
---

### 1)

Inicialmente he creado una escena sencilla con un terrain y he añadido 3 modelos de la _AssetStore_, concretamente del paquete **_"PolygonStarter"_**.

![imagen](/media/1.1.png)

Se puede observar que les he aplicado unas texturas para darles color.

La idea es hacer un juego en tercera persona, por lo tanto he creado un script que controla al personaje, similar al de prácticas anteriores y otro para la cámara.

Básicamente la cámara se mueve cuando se mueve el jugador y además si el jugador rota la cámara rota sobre el jugador para mantener siempre la misma vista del jugador.

![imagen](/media/1.2.png)
![gif](/media/1.3.gif)

Se nos pide que cuando el jugador colisione con el objeto de tipo B, el objeto tipo A mostrará un mensaje por consola.

Y cuando el objeto A sea tocado por el jugador, se le aumentará un contador en el objeto B.

Tipo A (el hombre)
![imagen](/media/1.4.png)

Tipo B (la mujer)
![imagen](/media/1.5.png)
![gif](/media/1.6.gif)

### 2)

Como controlador de escena usaré la cámara, ya que siempre está presente en la escena.

#### a)

Para añadir la opción de poder disparar he añadido el evento _playerShoot_ en la cámara, playerShoot estará suscrito al método _disparar_ del jugador. Además el jugador tiene 2 eventos _destroyA_ y _empujarA_ que estarán suscritos a los métodos que se llaman igual de los objetos, el destroyA del objeto tipo A más cercano y el empujarA del segundo A más cercano. 

Además, después de llamar a esos métodos se desuscribirá de ambos, de forma lógica:

- si está lo suficientemente cerca como para ser destruido, no será empujado, es decir se desuscribe de empujarA y se suscribe a destroyA.

- si esta lo suficientemente cerca para ser empujado pero no para ser destruido, se desuscribe del destroyA y se suscribe a empujarA.

- si está lejos como para ser empujado o destruido se desuscribirá de ambos.

![imagen](/media/2.a.png)
![gif](/media/2.a.1.gif)

#### b)

El apartado b consiste en añadir al controlador del juego que si un objeto de tipo B choca con el jugador, todos sufren un cambio físico. Además, decrementarán el poder del jugador.  

Los objetosB están suscritos a un evento del controlador del juego, que está en la cámara, a una función de la cámara llamado _playerTouchB_ que recoge todos los objetos con la etiqueta B en un vector. Después, recorro el vector entero y le cambiamos el color a todos los objetos B al mismo color.

![imagen](/media/2.b.png)
![gif](/media/2.b.1.gif)


Para bajarle el poder al jugador, cree un método del controlador del jugador que se llama _bajarPoder_. El controlador (la cámara) tiene un evento también de tipo **playerEvent** llamado _decreasePower_ que está suscrito al método bajarPoder del jugador. Este evento es llamado desde el método playerTouchB del controlador.

![imagen](/media/2.b.2.png)

Además adapté el delegate del tipo de empujarA para del ObjectA que reciba el float de la fuerza del jugador. 

El poder del jugador influirá escalarmente en la fuerza con la que se empuja a los objetos tipo A, esta no puede disminuir de 1.