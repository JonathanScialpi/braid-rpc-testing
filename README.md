# braid-rpc-testing
Send an RPC from .NET App to Corda Node


1. Navigate to your project's root directory and build your project with ./gradlew clean deployNodes
2. Then start your nodes with build/nodes/runnodes
3. Navigate to the directory where you are keeping your braid-server jar file and start the braid server using:

java -jar .\braid-server-4.1.2-RC13.jar [localhost:YOUR_PORT] [NODE_USERNAME] [NODE_PASSWORD] [YOUR_PORT] [OPEN_API_VERSION] [YOURNODE_CORDAPP_DIRECTORY]

java -jar .\braid-server-4.1.2-RC13.jar localhost:10006 user1 test 8999 3 'C:\Users\Jonathan Scialpi\Desktop\dev\braid-rpc-testing\sendfile-Attachments\build\nodes\Buyer\cordapps'

4. Review your http://localhost:8999/swagger.json file to find your flow path like below:
- http://localhost:8999/api/rest/network/nodes
- http://localhost:8999/api/rest/cordapps/workflows/flows/net.corda.examples.sendfile.flows.SendAttachment

5. Execute the program.cs script OR just make a REST request from any application with the required parameters
