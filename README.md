# capies

人の知的生産活動を支援する基盤環境を提供するためのリポジトリです。

## JupyterLabs 用 Docker コンテナの使い方

このリポジトリで提供している、JupyterLabs 用の Docker コンテナの使い方を説明します。

以下では Windows 10 を使っていることを前提にしています。

### 必要なもの

* [Git for windows](https://gitforwindows.org/)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Docker コンテナの起動

1. Git for windows と Docker Desktop をインストールします。

2. Git Bash を起動して、お好みのフォルダに移動します。
   例えば、C:\Users\user\workのフォルダで作業を行いたい場合は、次のコマンドを実行します。

   ```
   $ cd /c/Users/user/work
   ```

   $ はプロンプト(コマンドの入力を待ち受けるときに表示される記号)ですので、入力する必要はありません。

3. git コマンドを実行して、Github にあるソースコード一式をダウンロードします。

   ```
   $ git clone https://github.com/hanaue51/capies.git
   ```

   コマンドを実行すると、capies というフォルダの中に、ソースコード一式がダウンロードされます。

4. capies フォルダに移動して、ローカル環境用の Docker コンテナを起動します。

   ```
   $ cd capies/docker
   $ docker-compose up -d
   ```

   Docker コンテナの起動に必要な処理が行われます。これにはしばらく時間がかかります。
   画面に次のように表示されたら、Docker コンテナの起動が完了しています。

   ```
   Creating network "docker_default" with the default driver
   Creating docker_notebook_1 ...
   Creating docker_notebook_1 ... done
   ```

5. JupyterLabsが使えることを確認します。ブラウザを起動して、http://localhost:8888 にアクセスします。
   Docker コンテナが正しく起動していれば、下の図のような JupyterLabs の画面が表示されます。
   ![JupyterLabsランチャー画面](C:\works\ies\kb\resources\jupyterlabs_launcher.png)



### Docker コンテナの停止

停止させる方法は2つあります。

#### ブラウザから停止させる場合

JupyterLabs のメニューから、File→Shut Down を選びます。

確認ダイアログが出るので、「Shut Down」の赤いボタンをクリックします。

Server stopped のメッセージが表示されたら、ブラウザのタブを閉じます。

#### Git Bash から停止させる場合

Docker コンテナの起動時に docker-compose を実行したフォルダで、次のコマンドを実行します。

```
$ docker-compose down
```

次のようなメッセージが表示されたら、JupyterLabs を表示させていたブラウザのタブを閉じます。

```
Stopping docker_notebook_1 ...
Stopping docker_notebook_1 ... done
Removing docker_notebook_1 ...
Removing docker_notebook_1 ... done
Removing network docker_default
```

停止させた後にもう一度 Docker コンテナを起動したい場合は、Git Bash で docker-compose を実行したフォルダに移動し、次のコマンドを実行します。

```
$ docker-compose up -d
```

