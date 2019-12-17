from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key = 'secret af'

@app.route('/')
def index():
  if 'count' not in session:
    session['count'] = 0
  session['count'] = session['count'] + 1
  return render_template('index.html')

@app.route('/add2')
def add_two():
  session['count'] = session['count'] + 1
  return redirect ('/')

@app.route('/destroy_session')
def clear(): 
  session['count'] = 0
  return redirect ('/')


if __name__ == "__main__":
  app.run(debug=True)