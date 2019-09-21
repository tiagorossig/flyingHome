// stick in PlayerPlatformerController.cs when ready
// incomplete by itself

        // disables branch collision when comes in contact with beetle
        void OnTriggerEnter2D(Collider2D other)
        {
            // find all GameObjects tagged as Branch
            GameObject[] branches = GameObject.FindGameObjectsWithTag("Branch");
            if (other.tag == "Beetle")
            {
                // disables branch collision
                foreach (GameObject branch in branches) 
                    branch.GetComponent<BoxCollider2D>().enabled = false;
                // could also disable beetle collision
                // other.GetComponent<BoxCollider2D>().enabled = false;
                // begins waiting routine
                StartCoroutine(EnableBox(.8F));
            }

            IEnumerator EnableBox(float waitTime)
            {
                // waits for set amount of time
                yield return new WaitForSeconds(waitTime);
                // turns on branch collision
                foreach (GameObject branch in branches)
                    branch.GetComponent<BoxCollider2D>().enabled = true;
                // if also diabling beetle collision
                // other.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
