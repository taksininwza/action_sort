class Vertex {
    [ID: string]: string[]
}

class Graph {
    adjancentList: Vertex = {}
    numberOfNodes: number = 0

    addVertex(node: string) {
        this.numberOfNodes++
        this.adjancentList[node] = []
    }
    addEdge(node1: string, node2: string) {
        this.adjancentList[node1].push(node2)
        this.adjancentList[node2].push(node1)
    }
    showConnections() {
        const allNodes = Object.keys(this.adjancentList)
        for (const node of allNodes) {
            const edges = this.adjancentList[node as keyof object]
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