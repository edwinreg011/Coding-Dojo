from flask import Flask, render_template, request
app = Flask(__name__)

@app.route('/')
def index():
  return render_template ('index.html')

@app.route('/results', methods = ['post'] )
def results():
  print('*'*50)
  print(request.form)
  return render_template('results.html', name = request.form['name'], dojo = request.form['dojo'], language = request.form['language'], comment = request.form['comment'], gender = request.form['gender'], communication = request.form['comm'])

if __name__ == "__main__":
    app.run(debug=True)