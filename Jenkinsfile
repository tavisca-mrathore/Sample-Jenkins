pipeline{
    agent { label 'master' }
    parameters{
        string(
            name: "GIT_HTTPS_PATH",
            defaultValue: "https://github.com/tavisca-mrathore/Sample-Jenkins.git",
            description: "GIT HTTPS PATH"
        )
        string(
            name: "SOLUTION_PATH",
            defaultValue: "HiHelloWebAPI/HiHelloWebAPI.sln",
            description: "SOLUTION_PATH"
        )
        string(
            name: "TEST_SOLUTION_PATH",
            defaultValue: "HiHelloWebAPI.Tests/HiHelloWebAPI.Tests.csproj",
            description: "TEST SOLUTION PATH"
        )
        
        string(
            name: "PROJECT_PATH",
            defaultValue: "HiHelloWebAPI/HiHelloWebAPI.csproj",
            description: "TEST SOLUTION PATH"
        )
        choice(
            name: "RELEASE_ENVIRONMENT",
            choices: ["Build","Test", "Publish"],
            description: "Tick what you want to do"
        )
    }
    stages{
        stage('Build'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Build" || params.RELEASE_ENVIRONMENT == "Test" || params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps{
                bat '''
                    dotnet C:/sonar/SonarScanner.MSBuild.dll begin /k:"WebApi" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="97f6478d8f02dc2dce314b208ad338fd647e72a1"
                    echo '====================Build Project Start ================'
                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json
                    echo '=====================Build Project Completed============'
                    echo '====================Build Project Start ================'
                    dotnet build ${PROJECT_PATH} 
                    echo '=====================Build Project Completed============'
                '''
            }
        }
        stage('Test'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Test" || params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps{
                bat '''
                    echo '====================Build Project Start ================'
                    dotnet test ${TEST_SOLUTION_PATH}
                    echo '=====================Build Project Completed============'
                    dotnet C:/sonar/SonarScanner.MSBuild.dll end /d:sonar.login="97f6478d8f02dc2dce314b208ad338fd647e72a1"
                '''
            }
        }
        stage('Publish'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps{
                bat '''
                    echo '====================Build Project Start ================'
                    dotnet publish ${PROJECT_PATH}
                    echo '=====================Build Project Completed============'
                '''
            }
        }
        stage ('push artifact') {
            when{
                expression{params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps {
                powershell'''
                zip zipFile: 'publish.zip', archive: false, dir: 'HiHelloWebAPI/bin/Debug/netcoreapp2.2/publish'
                archiveArtifacts artifacts: 'publish.zip', fingerprint: true
                '''
            }
        }
    }
    post{
        always{
            deleteDir()
       }
    }
}
