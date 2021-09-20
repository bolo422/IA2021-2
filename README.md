# IA2021-2

#Exercício 1: Testes com IA
	> Este está dentro dos scripts "Seek.cs" e "Flee.cs" (os nomes já entregam o tipo de IA) e também "PathFollowing.cs" que serve para seguir os waypoints.

#Exercício 2: Rato e o labirinto
	> Este está dividido em 2 partes: Pathfinding com A* e depois o movimento do rato com "PathFollowing.cs" (do exercício anterior)
	A primeria parte é divido em 3 scritps, "grid.cs" "node.cs" "pathfinding.cs", os dois primeiros geram um Grid com base nos parametros colocados no inspector, o grid é criado em formato de fila, então ele é baseado nos nodos. Depois do grid ser criado o Pathfinding recebeo ponto inicial e final e calcula a rota mais curta com um algorítimo A*