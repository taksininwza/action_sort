class Vertex {
    [ID: string]: string[]
}

class Graph {
    adjacentList: Vertex = {}
    numberOfNodes: number = 0

    addVertex(node: string) {
        this.numberOfNodes++
        this.adjacentList[node] = []
    }
    addEdge(node1: string, node2: string) {
        this.adjacentList[node1].push(node2)
        this.adjacentList[node2].push(node1)
    }
    showConnections() {
        const allNodes = Object.keys(this.adjacentList)
        for (const node of allNodes) {
            const edges = this.adjacentList[node as keyof object]
            let connections = ''
            for (const edge of edges) {
                connections += edge + ' '
            }
            console.log(node + ' --> ' + connections)
        }
    }
}

const g = new Graph()
g.addVertex('0')
g.addVertex('1')
g.addVertex('2')
g.addVertex('3')

g.addEdge('0', '2')
g.addEdge('2', '1')
g.addEdge('2', '3')
g.addEdge('1', '3')

g.showConnections()