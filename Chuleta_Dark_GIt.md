# **Chuleta de control de versiones con git**

## 1. Conceptos mínimos que tenemos que saber sobre el control de versiones

* **Control de versiones**: El control de versiones es un sistema que registra los cambios realizados sobre un archivo o conjunto de archivos a lo largo del tiempo, de modo que puedas recuperar versiones específicas más adelante

* **Conceptos:**
    *  **Repositorio local**: Es una base de datos centralizado donde se guardan las distintas versiones de los ficheros sometidos a control de versiones.

    * **Copia local**: Es la copia que hacen los usuarios de un fichero sometido a control de versiones. El **DIRECTORIO LOCAL (working directory/working tree/workspace)** es el que contiene todas las copias locales. 

    * **Repositorio remoto**: Es una base de datos centralizada donde se guardan las distintas versiones de los ficheros sometidos a control de versiones, y reside en el servidor centralizado. 

    * ***Log***:  Registro de todos los cambios que se han producido en el repositorio. Es responsabilidad del cliente añadir información al log cuando se produce un cambio. También llamado histórico.

    * **Conflicto**: Problema que surge cuando los clientes realizan cambios incompatibles entre sí.

* **Estados del fichero**:
	* **Sin seguimiento**: archivos que solo son locales y no existen en el repositorio remoto.

    * **Confirmado(commited file)**: Es el fichero que ya está almacenado en el repositorio. La última versión y la copia local son iguales.

    * **Modificado(modified file)**: Es el fichero modificado en la copia local y existe una diferencia entre la copia local y la última versión en el repositorio. 

    * **Preparado**: (staged file)Es la copia del fichero modificado preparada para ser confirmada en la próxima operación de confirmación (COMMIT). La zona de preparación (staging area or index) contiene todos los ficheros preparados.

    * **Ignorado(ignored file)**: Es el fichero que está en el directorio local pero que deliberadamente no se somete a control de versiones. 

* **Operaciones**:
    * **Clone**: Realiza una copia de un repositorio remoto en un directorio local.
    
    * **Add**: Añade un archivo al siguiente commit.
    
    * **Commit**: Confirma los cambios en el repositorio local.
    
    * **Push**: Envía al repositorio remoto los cambios correspondientes a los commits realizados desde el último push.
    
    * **Pull**: Descarga desde el repositorio remoto los archivos actualizados en commits que hayan realizado otros usuarios, y los integra (realiza un merge) con el repositorio local.
    
    * **Fork**: Crear una copia de un repositorio. Esto es especialmente útil para modificar proyectos sin afectar al proyecto original.
    
    * **Pull Request**: Petición de un pull, para que un nivel superior a una rama u otra rama distinta incorpore cambios (commits) de esta.
    
* **Servicios de repositorio remoto**: GitHub, GitLab, BitBucket, etc.

* **Clientes gráficos para el control de versiones**: gitg, gitkraken, gitblade, sourcetree, etc.


## 2. Que tenemos que saber hacer con Git (y GitHub)

### 2.1. Interprete de comando de git-bash
Comando    | Argumentos              | Función 
-----------|-------------------------|------------
**pwd**    |                         | Muestra el directorio actual (Print Working Directory).
**mkdir**  | &lt;dir>                | Crea un directorio.
**cd**     | &lt;dir>                | Cambia de directorio (*'cd -': directorio previo*).
**ls**     | [-l] [-a]               | Muestra los archivos del directorio *(l: detallado; a: incluye ficheros ocultos).*
**rm**     | &lt;file>               | Elimina un fichero.
**mv**     | &lt;source> &lt;dest>   | Mueve o renombra un archivo.

### 2.2. Control de versiones local

Comando        		 | Argumentos         | Función 
---------------------|--------------------|------------
**git init**   		 |                    | Crea un repositorio local en el directorio actual.
**git add**    		 | &lt;file>          | Prepara ficheros para ser confirmados en un repositorio local.
**git commit** 		 | [-m &lt;message>]  | Confirma cambios en un repositorio local. *(m: permite escribir el mensaje del commit sin abrir el editor de texto).*
**git reset**  		 | &lt;file> 		  | Deshacer la operacion de preparar.
**git reset**  		 | [--soft]           | Deshace el add. *(soft: deshace el commit)*
**git status** 		 |					  | Identificar el estado de un fichero o ficheros en un repositorio local.
**git checkout**	 | file>   			  | Descartar los cambios de un fichero de trabajo mediante la recuperación de una versión almacenada en el repositorio local. 
**git checkout**     | &lt;branch_name>   | Cambia de rama en el repositorio local.
**git diff**   		 | &lt;file>          | Muestra los cambios de un archivo "modificado" con respecto al que hay en el repositorio.

### 2.3. Control de versiones centralizado

Comando        		 | Argumentos         								| Función 
---------------------|--------------------------------------------------|------------
**git config** 		 | [--global][--local] http.proxy &lt;domain:port>  | Configurar git para que trabaje trás un proxy.
**git clone**  		 | &lt;URL>               							| Replicar un repositorio remoto localmente en nuestra maquina.
**git remote** 		 | add &lt;URL>										| Replicar un repositorio local en un servidor remoto.
**git push** 		 | --all &lt;URL>			    					| Replicar un repositorio local en un servidor remoto.
**git pull** 		 | 		  											| Traer los cambios de un repositorio remoto a un repositorio local.
**git fetch** 		 | 		  											| Traer los cambios de un repositorio remoto a un repositorio local.
**git merge** 		 |            										| Resolver los conflictos que se pueden producir al traerse estos cambios.
**git commit**		 | [-m &lt;message>]
**git add**		 	 |					  								| Enviar los cambios de un repositorio local a uno remoto.
**git push**		 | &lt;remote> &lt;branch> 			   			    | Enviar una rama local al repositorio remoto.
**git pull** 	     | &lt;remote> 									    | Incorporar a ramas locales cambios que se producen en el repositorio remoto.
**git request-pull** | [-p] <start> <url> [<end>]			            | Realizar un pull-request entre dos ramas de un repositorio remoto.

### 2.4. Control de versiones distribuido

Comando              | Argumentos                   | Función 
---------------------|------------------------------|------------
**git branch**       | &lt;branch_name>             | Crea una rama nueva en el repositorio local.
**git push**         | [-u] &lt;remote> &lt;branch> | Envía la rama al repositorio remoto.

Operaciones de Github:

Operacion                                 | Descripción
------------------------------------------|------------
**pull request** (entre ramas)            | En la página principal del repositorio: "New pull request" y se selecciona la rama deseada
**pull request** (entre repositorios)     | Dentro de la misma opción anterior, seleccionando: "compare across forks"
